using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GUI_Task.Class;
using GUI_Task.StringFun01;
//
using System.Globalization; // for Date Culture
using GUI_Task.UC.McCB;
// Image Requirement
using System.IO;
using System.Data.SqlClient;
using Cyotek.Windows.Forms;
// Ctl+M, M (Toggle block expand/contract)
// Unfold all - Ctrl+M, Ctrl+L
// Fold all - Ctrl+M, Ctrl+O
using System.Linq;
using System.Net;

namespace GUI_Task
{

  
  public partial class frmCompanyLogo : Form
  {
    #region Class Level Fields
    // Form Control Variables
    DateTime fNow = DateTime.Now;                               // 01- Current Time Variable
    string fFormID = "202001";                                  // 01- Form ID
    bool fIsFormLoading = true;                                 // 02- By Default = true, To handle value changed event of ComboBox or Grid: when populating combo (if there is a dependency of controls)
    bool fImgLoading = false;                                   // 03- Is Image Loading
    bool fLoadingFormDataComplete = true;                       // 04- To Check, if combo is empty or other necessary data is incomplete
    bool fIsGridDataLoading = false;                            // 05- Form has Loaded and Doc is loading data in grid for editing)
    bool fAlreadyExists = false;                                // 04- Check for Modification or Insertion
    bool fIsBalloonToolTip = true;                              // 04- Type of tool tip Baloon or simple (at later stage it will be form Db Table)
    bool fIsActiveTvControl = false;                            // 05- for Tree View Control or Grid Control to handle Tab/Enter Key
    bool fIsActiveGridControl = false;                          // 06- Active Control is Grid (When Got Focus, off when Leave)
    int fTopCordinateMDIForm = 0;                               // 07- Top Cordinate of the form relative to MDI Form.
    int fLeftCordinateMDIForm = 0;                              // 08- Lrft Cordinate of the form relative to MDI Form.
    // Db Table Variables
    List<string> fDependentTables = new List<string>();         // 01- Dependent objects to check before Deletion of an Id
    string fTableNameMaster = "gds_invoicetran";                // 02- This forms Table Name Master
    string fKeyFieldName = "doc_id";                            // 03- This table's key field
    string fTableNameDetailBilty = "gds_invoicetranbilty";      // 04- Table Name Detail Bilty List
    string fTableNameDetailBill = "gds_invoicetranbill";        // 05- Table Name Detail Bill/Services Items 

    string fGLCOA = "gl_ac";                                    // 04- GL / Fin COA
    // Query Variables
    string fFieldListforDML = string.Empty;                     // 01- Field List for Update / Insert fields
    string fFieldListReadOnly = string.Empty;                   // 02- Field List for Readonly.
    string fQryforDML = string.Empty;                           // 03- Query for DML for the controls
    string fQryReadOnly = string.Empty;                         // 04- Query for ReadOnly Fields for the controls
    string fAddWhere = string.Empty;                            // 04- Additional Where
    string fAddWhereAr = string.Empty;                          // 05- Additional Where AR = Customer
    List<string> fManySQL;                                      // 06- fOneSQL/fManySQL Query List for Detail Master or Insert/Update
    List<string> fAdvanceQry;                                   // 07- Advance Query
    // Menu / Navigation Variables
    ContextMenuStrip cMMasterForm;                              // 01- Context Menu: ContextMenu is obselete (now ContextMenuStrip)
    Int64 fCboGridIndex = 0;                                    // 02- Hold Index Value of Combo Box for Grid  
    Int64 fCboGridIndexItem = 0;                                // 02- Hold Index Value of Combo Box for Grid  
    Int64 fCboGridIndexUom = 0;                                 // 02- Hold Index Value of Combo Box for Grid  
    //MenuItem[] cMSMasterFormMenuItem;                         // 02- Context Menu Items (NA)
    ContextMenuStrip cMdGvBilty;                                // 03- Context Menu
    ContextMenuStrip cMdGvBill;                                 // 04- Context Menu
    string fLastID = string.Empty;                              // 05- Last Id Saved in the Table  

    int fLastRow = 0;                                           // 04- Last row number of the Grid.
    // Validation / Lists / Error Variables
    string fZeroStr = "000000000000000000000000000000";         // 01- String of Zeros (for concatination purposes)
    List<Tuple<string, string, string>> fArGLAcList;            // 02- List to Control Range of valid accounts
    List<Tuple<string, string, string>> fBIltyExpenseGLAcList;  // 03- List to Control Range of valid accounts for Bilty Expenses
    string fErrrMsg = string.Empty;                             // 04- Error message used for validation or other purposes
    int fTranErr = 0;
    // Coding / Integration Variables
    Int64 fAddressUID = 0;                                      // 01- Address unique ID
    string fAcStrID = string.Empty;                             // 02- Fin COA string ID
    Int64 fAcID = 0;                                            // 03- Fin Numeric ID
    string fAcTitle = string.Empty;                             // 04- Fin Title
    int fAcControlIdRange = 0;                                  // 05- Account Id Range  type = AR, AP etc for Search filtering purposes.
    DateTime fDocDateStart;
    DateTime fDocDateEnd;
    Int64 fNewId = 0;                                           // xx- New Id (for new inserted record to display in Alert )
    // User Rights
    bool isRightsEmpty = false;                                 // 01- if user has no rights    
    // This Form Specific
    string fColFormat = string.Empty;                           // 01- Column format variable for multiple use. 
    int fcboToDefaultValue = 0;                                 // Second City Id
    bool fIsIdConfirmed = false;                                // ?
    string fAddWhereBe = string.Empty;
    // Attachment / Image
    string fImagePath = string.Empty;
    string fImageName = string.Empty;
    string fImageExt = string.Empty;
    string fImageSize = string.Empty;
    bool fIsNewImageLoaded = false;

    #endregion Class Level Fields
    // Constructor
    public frmCompanyLogo()
    {
      InitializeComponent();
    }
    //
    private enum ImageSize
    {
      Small = 0,
      Medium = 1,
      Large = 2,
      Screen = 3,
      Other = 4,
      Default = 5
    }
 
    private void frmBilty_Load( object sender, EventArgs e )
    {
      try
      {
        SetFormLayout();                                          // 01- Form Size, Position, Type
        SetControlMask();                                         // 02- Mask for Text Boxes, Max Length, Auto Save Settings
        SetControlToolTips();                                     // 03- Add tool tips to the controls
        SetContextMenuForm();                                     // 04- Set Context Menu Form
        //SetContextMenuGrid();                                     // 05- Set Context Menu Grid
        LoadDataIntegration();                                    // 08- Load Integration Data like, Control Accounts, and Integration with other modules  (if any)
        LoadDataCbo();                                            // 06- Load Data For ComboBox (if any) 
        //SetGridLayout();                                          // 07- Set Grid Headers (if any)
        //SetInitialData();                                       // 09- Load Initial Data necessary for the form if any (dependent table list)  (if any)
        //HideControls();                                         // 10- Hide Controls kepts for future or discarded (but necessary for DML)  (if any)
        SetCurrentDate();
        clsMasterFormRequired CheckRequired = new clsMasterFormRequired();
        string lValidationError = CheckRequired.RequiredControls(this.Controls, true);
        // This Shoould/Must be the Last Segment of the Code Block
        fIsFormLoading = false;
        ShowImageText();
        this.ActiveControl = cboGroup;
      }
      catch (Exception ex)
      {
        MessageBox.Show("Exception, Load Form: " + ex.Message, lblFormTitle.Text.ToString());
      }
    }
    private void frmBilty_KeyDown( object sender, KeyEventArgs e )
    {
      try
      {
        if (e.KeyCode == Keys.Enter)
        {
          if (!fIsActiveGridControl)
          {
            e.Handled = true;
            SendKeys.Send("{TAB}");
          }
        } // end if
      }
      catch (Exception ex)
      {
        MessageBox.Show("Exception, Tab <Enter>: " + ex.Message, lblFormTitle.Text.ToString());
      }
    }
    // ----------------------------------------------------- Load Methods ---------------------------------------------------------------------------
    // 01-
    private void SetFormLayout()
    {
      try
      {
        KeyPreview = true;
        lblFormTitle.Text = "Company Logo";
        this.Text = clsGVar.CoTitle + "  [ " + clsGVar.YrTitle + " ]";
        //
        this.MinimumSize = new Size(650, 425);
        this.Top = clsGVar.frmTopGeneralIds;
        this.Left = clsGVar.frmLeftGeneralIds;
        //
        clsGVar.SetFormColorGL(lblTopLine1, lblTopLine2, lblTopLine3);
        //

      }
      catch (Exception ex)
      {
        MessageBox.Show("Exception, Setting Form Layout: " + ex.Message, lblFormTitle.Text.ToString());
      }
    }
    // 02-
    private void SetControlMask()
    {
      try
      {
        //
        // 0- Marker
        // 1- Field Number for maping with table field name
        // 2- Type of Field
        // 3- Clear Flag (Clear data on press of Clear button)
        // 4- D or d Default Clear Value or specific value
        // 5- Required or optional against Empty or null
        // R or r = required
        // 6- Remarks or Control's Name for Displaying Error or Messages.
        // Note: d or D for default value after clear.
        // other wise this field is also used for specific default value.
        //
        // for example textSTN.Tag = ">><<,02,string,clear,this is specific default value";
        // string,int,bool,double
        //
        int lCount = 0;
        cboGroup.Tag = ">><<," + clsDbManager.ConvStrFixLen(lCount++, 2) + ",int,clear,d,R,Bilty Broker,RW";                                // 14- Shipping Line Id
        cboCompany.Tag = ">><<," + clsDbManager.ConvStrFixLen(lCount++, 2) + ",int,clear,d,R,Bilty Broker,RW";                                // 14- Shipping Line Id

        //
        // ReadOnly Controls at the end
        //
        fFieldListforDML = "   doc_date";                               // 00- Document Date
        fFieldListforDML += ", doc_ref";                                // 01- Doc. Reference / Manual Id
        fFieldListforDML += ", doc_company_id";                         // 02- Company
        
        

      }
      catch (Exception ex)                                              
      {
        MessageBox.Show("Exception, Setting Masks: " + ex.Message, lblFormTitle.Text.ToString());
      }
    }
    // 03-
    private void SetControlToolTips()
    {
      try
      {
        if (fIsBalloonToolTip)
        {
          tTMDtl.IsBalloon = true;
        }
        else
        {
          tTMDtl.IsBalloon = false;
        }
        //
        // ToolTip Main Buttons:
        tTMDtl.SetToolTip(btn_Save, "Alt + S, Save New record or Modify/Update an existing Voucher/Doc.");
        tTMDtl.SetToolTip(btn_SaveNContinue, "Alt + E, Save data and continue work on current Voucher/Doc.");
        tTMDtl.SetToolTip(btn_Clear, "Alt + C, Clear input of Account ID section.");
        tTMDtl.SetToolTip(btn_Delete, "Alt + D, Delete currently selected Voucher/Doc.");
        tTMDtl.SetToolTip(btn_Exit, "Alt + X, Close this form and exit to the Main Form.");
        //
        tTMDtl.SetToolTip(cboGroup, "Group of Companies");
        tTMDtl.SetToolTip(cboCompany, "Companies under the group");
        //
      }
      catch (Exception ex)
      {
        MessageBox.Show("Exception, Load Tool Tips: " + ex.Message, lblFormTitle.Text.ToString());
      }
    }
    // 04-
    private void SetContextMenuForm()
    {
      cMMasterForm = new ContextMenuStrip();
      this.ContextMenuStrip = cMMasterForm;
      try
      {
        // 1- Title of Menu
        // 2- null (image)
        // 3- Event Handler (Note There is no entry in the Designer)
        //cMMasterForm.Items.Add("Show Last ID", null, cMSMasterFormMenuItem_LastID_Click);
        //cMMasterForm.Items.Add("Generate Next ID", null, cMSMasterFormMenuItem_NextID_Click);
        //cMMasterForm.Items.Add("Show Lookup", null, cMSMasterFormMenuItem_LookUp_Click);

      }
      catch (Exception ex)
      {
        MessageBox.Show("Exception Context Menu Form: " + ex.Message, lblFormTitle.Text.ToString());
      }
    }
    // 05-
    // 06-
    private void LoadDataCbo()
    {
      try
      {
        string lTableName = string.Empty;
        string lPreFix = string.Empty;
        string lSQl = string.Empty;
        lTableName = "";
        lPreFix = "";
        // Group
        lTableName = "cogrp";
        lPreFix = "cogrp";
        cboGroup.DropDownStyle = ComboBoxStyle.DropDownList;
        lSQl = "select " + lPreFix + "_id, " + lPreFix + "_title from " + lTableName;
        lSQl += " order by ordering";
        //
        clsFillCombo.FillComboWithQry(
            cboGroup,
            lTableName + "," + lPreFix + "_id" + ",False",
            lSQl
            );


        // Company
        LoadDataCboCompany();
        //
        cboImageSize.DropDownStyle = ComboBoxStyle.DropDownList;
        FillComboWithEnumLocal(cboImageSize, "ImageSize", false);

        //
      } // end try
      catch (Exception ex)
      {
        MessageBox.Show("Exception, Load Cbo: " + ex.Message, lblFormTitle.Text.ToString());
      }
    }
    private void FillComboWithEnumLocal( ComboBox pCbo, string pEnumName, bool pSort )
    { 
        List<NameValuePair> ControlGroupList = new List<NameValuePair>();
        var values = Enum.GetValues(typeof(ImageSize))
        .Cast<ImageSize>()
        .Select(d => Tuple.Create((( int )d).ToString(), d.ToString()))
        .ToList();  // it is ok but it is comma seperated list.
        //
        foreach (var item in values)
        {
          string lName = item.Item2.ToString().Replace('_', ' '); ;
          string lValue = item.Item1.ToString();
          NameValuePair NvP = new NameValuePair(lName, Convert.ToInt32(lValue));
          ControlGroupList.Add(NvP);
        }
        if (pSort)
        {
          ControlGroupList.Sort(NameValuePair.NameComparison);
        }
        //
        pCbo.DataSource = ControlGroupList;
        pCbo.DisplayMember = "NameStr";
        pCbo.ValueMember = "ValueInt";
    }
    //
    private void SetGridLayout()
    {
    }
    // 08-
    private void LoadDataIntegration()
    {
      try
      {
        // Dependent Tables
        fDependentTables.Add("Bilty Voucher,gds_Voucherdtl,doc_bilty_id,N");

      }
      catch (Exception ex)
      {
        MessageBox.Show("Exception, Load Integration Data: " + ex.Message, lblFormTitle.Text.ToString());
      }
    }
    // 09-
    private void SetInitialData()
    { 
      // blank
    }
    // 10-
    private void HideControls()
    { 
      // blank
    }
    //    
    private void dGv_Leave( object sender, EventArgs e )
    {
      fIsActiveGridControl = false;
    }
    // 9-

    // ---------------------------------------------------- Clear Form ---------------------------------------------------------------------------
    private void btn_Clear_Click( object sender, EventArgs e )
    {
      ClearThisForm();
    }
    //
    private void ClearThisForm()
    {
      try
      {
        // Master Data
        //mtDocId.Text = string.Empty;
        clsMasterFormClear.ClearControls(this.Controls);
        //mtDocId.Enabled = true;
        SetCurrentDate();
        EnableDDisableButtons(true);
        SetResetVariables();
        //
        iBAttach.Image = null;
        iBAttach.Image = TLERP.Properties.Resources.BaBa_Attach_bg_small;
        fIsNewImageLoaded = false;
        //mtDocId.Focus();
        cboGroup.Focus();
      }
      catch (Exception ex)
      {
        MessageBox.Show("Exception, Clear Form: " + ex.Message, lblFormTitle.Text.ToString());
      }
    }

    private void SetResetVariables()
    {
      fAlreadyExists = false;
    }

    private void SetCurrentDate()
    {
    }
    //
    private void EnableDDisableButtons( bool pFlage )
    {
      // things to dp
      btn_Save.Enabled = pFlage;
      btn_Delete.Enabled = pFlage;
      //btn_Clear.Enabled = pFlage;
      //btn_SaveNContinue.Enabled = pFlage;
      //btn_View.Enabled = pFlage;
    }
    // ===================================================== Clear Form ===========================================================================
    // ----------------------------------------------------  ---------------------------------------------------------------------------
    private void btn_Exit_Click( object sender, EventArgs e )
    {
      this.Close();
    }
    //
    private void frmBilty_FormClosing( object sender, FormClosingEventArgs e )
    {
      try
      {
        //if (lblCustomerTitle.Text.ToString().Trim().Length > 0)
        //{
        //  if (MessageBox.Show("Are You Sure To Exit the Form ?", "Closing: " + lblFormTitle.Text.ToString(), MessageBoxButtons.OKCancel) != DialogResult.OK)
        //  {
        //    e.Cancel = true;
        //  }
        //}

      }
      catch (Exception ex)
      {
        MessageBox.Show("Exception, Form Closing: " + ex.Message, lblFormTitle.Text.ToString());
      }
    }
    // ===================================================== Menu & Misc  ===========================================================================

    // ---------------------------------------------------- Save / DML Block ---------------------------------------------------------------------------
    private void btn_Save_Click( object sender, EventArgs e )
    {
      //SaveClick(false);
      SaveImage();
    }

    private void btn_SaveNContinue_Click( object sender, EventArgs e )
    {
      SaveImage();
    }
    //
    // Save Image
    private void SaveImage()
    {
      //Int64 lNextID = clsDbManager.GetNextValDocID("img_attach", "attach_id", clsGVar.LGCY, "");
      try
      {
        if (!fIsNewImageLoaded)
        {
          MessageBox.Show("Old Image or new image not loaded, try to re-load the image...", lblFormTitle.Text.ToString());
          return;
        }
        SqlConnection conn = new SqlConnection(clsGVar.ConString1);
        SqlCommand cmd = new SqlCommand("cologo", conn);            // Stored Procedure Name
        //SqlCommand cmd = new SqlCommand();
        //conn.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "cologo";
        conn.Open();
        // ------------------ Header Fields -----------------------------
        Image votingBackgroundImage = iBAttach.Image;
        Bitmap votingBackgroundBitmap = new Bitmap(votingBackgroundImage);
        Image votingImage = ( Image )votingBackgroundBitmap;
        var maxheight = (votingImage.Height * 3) + 2;
        var maxwidth = votingImage.Width * 2;
        //
        byte[] defaultImageData = ImageToByteArrayIB(iBAttach);

        cmd.Parameters.Add("@parentid", SqlDbType.Int).Value = int.Parse(cboGroup.SelectedValue.ToString() );
        cmd.Parameters.Add("@co", SqlDbType.Int).Value = int.Parse(cboCompany.SelectedValue.ToString());
        cmd.Parameters.Add("@ImageType", SqlDbType.Int).Value = int.Parse(cboImageSize.SelectedValue.ToString());
        cmd.Parameters.Add("@imagedata", SqlDbType.VarBinary).Value = defaultImageData;

        //SqlParameter blobParam = new SqlParameter("@imagedata", SqlDbType.VarBinary, buffer.Length);
        //blobParam.Value = buffer;
        //cmd.Parameters.Add(blobParam);
        //cmd.Parameters.Add("@Pattach_img", SqlDbType.b  ).Value = defaultImageData );
        // not working: cmd.Parameters.Add("@Pattach_img", SqlDbType.VarBinary  ).Value = defaultImageData );
        // working: cmd.Parameters.AddWithValue("@imagedata", defaultImageData);    // 4   
        // Add the return value parameter
        // Execute the insert
        int n = cmd.ExecuteNonQuery();
        if (n > 0)
        {
          MessageBox.Show("Image Saved, Rows Effected: " + n.ToString() + " ID: " + "", lblFormTitle.Text.ToString());
          fIsNewImageLoaded = false;
        }
        else
        {
          MessageBox.Show("Image not saved, check error log", lblFormTitle.Text.ToString());
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show("Exception Save Image: " + ex.Message, "Image: " + lblFormTitle.Text.ToString());
      }
    }
    private byte[] ImageToByteArrayIB( ImageBox pbImage )
    {
      try
      {
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        pbImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        return ms.ToArray();

      }
      catch (Exception ex)
      {
        MessageBox.Show("Exception: " + ex.Message,lblFormTitle.Text.ToString() );
        return null;
      }
    }
    private byte[] ImageToByteArray( System.Windows.Forms.PictureBox pbImage )
    {
      try
      {
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        pbImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        return ms.ToArray();

      }
      catch (Exception ex)
      {
        MessageBox.Show("Exception: " + ex.Message,lblFormTitle.Text.ToString() );
        return null;
      }
    }

    private Image byteArrayToImage( byte[] byteBLOBData )
    {
      try
      {
        MemoryStream ms = new MemoryStream(byteBLOBData);
        Image returnImage = Image.FromStream(ms);
        return returnImage;

      }
      catch (Exception ex)
      {
        MessageBox.Show("Exception: " + ex.Message, lblFormTitle.Text.ToString());
        return null;
      }
    }

    private bool FormValidation()
    {
      return true;
    }
    //
    private void btn_Delete_Click( object sender, EventArgs e )
    {
      string lDependencyFound = "";

      try
      {
        if (fDependentTables != null)
        {
          //lDependencyFound = clsCheckTableDependency.CheckTableDependency(
          //  fDependentTables,
          //  mtDocId.Text.ToString(),
          //  ""
          //  );
          if (lDependencyFound != "Dependency Not Found")
          {
            MessageBox.Show("Warnning:\nDelete not possible, following table(s) contain record(s)\n" + lDependencyFound, lblFormTitle.Text.ToString());
            return;
          }
          else
          {
            DeleteExistingId();
          }
        } // End if != null
        else
        {
          DeleteExistingId();
        } // End else != null
      }
      catch (Exception ex)
      {
        MessageBox.Show("Exception, Button, Deleting Id: " + ex.Message, lblFormTitle.Text.ToString());
      }
    }
    //
    private void DeleteExistingId()
    {
      //try
      //{
      //  // Confirmation Message
      //  if (MessageBox.Show("Are You Sure Really want to Delete ?", lblFormTitle.Text.ToString(), MessageBoxButtons.OKCancel) == DialogResult.OK)
      //  {
      //    string lSQL = string.Empty;
      //    List<string> lDelSQL = new List<string>();
      //    // Master Table
      //    lSQL = "Delete from " + fTableNameMaster;
      //    lSQL += " where ";
      //    lSQL += clsGVar.LGCY;
      //    lSQL += " and ";
      //    lSQL += fKeyFieldName + " = " + mtDocId.Text.ToString();
      //    lDelSQL.Add(lSQL);
      //    // Detail Item
      //    lSQL = "Delete from " + fTableNameDetailBilty;
      //    lSQL += " where ";
      //    lSQL += clsGVar.LGCY;
      //    lSQL += " and ";
      //    lSQL += fKeyFieldName + " = " + mtDocId.Text.ToString();
      //    lDelSQL.Add(lSQL);
      //    //
      //    if (clsDbManager.ExeMany(lDelSQL))
      //    {
      //      textAlert.Text = "Existing ID: " + mtDocId.Text.ToString() + " Deleted ....";
      //      MessageBox.Show("ID: " + mtDocId.Text.ToString() + " : " + mtDocDate.Text.ToString() + "\r\nDeleted... ", lblFormTitle.Text.ToString());
      //      ClearThisForm();
      //      return;
      //    }
      //    else
      //    {
      //      textAlert.Text = "ID: " + mtDocId.Text.ToString() + " Not Deleted: Try again....";
      //      return;
      //    }
      //  } // End Confirmation if
      //}
      //catch (Exception ex)
      //{
      //  MessageBox.Show("Deleting ID:\n Exception: " + ex.Message, lblFormTitle.Text.ToString());
      //}
    }
    //
    //
    //
  
    // 
    //
    private void EnableDisableButtons( bool pFlage )
    {
      // things to dp
      btn_Save.Enabled = pFlage;
      btn_Delete.Enabled = pFlage;
      //btn_Clear.Enabled = pFlage;
      //btn_SaveNContinue.Enabled = pFlage;
      //btn_View.Enabled = pFlage;
    }

    private void cboGroup_SelectedIndexChanged( object sender, EventArgs e )
    {
      try
      {
        //#region CboBank Changed
        if (!fIsFormLoading)
        {
          LoadDataCboCompany();
          iBAttach.Image = TLERP.Properties.Resources.BaBa_Attach_bg_small;
          fIsNewImageLoaded = false;
        }
        //#endregion
      }
      catch (Exception ex)
      {
        MessageBox.Show("Exception: " + ex.Message, lblFormTitle.Text.ToString());
      }

    }
    private void LoadDataCboCompany()
    {
      if (cboGroup.SelectedIndex != null)
      {
        string lTableName = "coco";
        string lPreFix = "coco";
        string lSQL = "";
        cboCompany.DropDownStyle = ComboBoxStyle.DropDownList;
        lSQL = "select " + lPreFix + "_id, " + lPreFix + "_title from " + lTableName;
        lSQL += " where ";
        lSQL += "coco_pid = " + cboGroup.SelectedValue.ToString();
        lSQL += " order by ordering";
        //
        clsFillCombo.FillComboWithQry(
            cboCompany,
            lTableName + "," + lPreFix + "_id" + ",False",
            lSQL
            );
        //fcboBankDefaultValue = Convert.ToInt16(cboCompany.SelectedValue);
      }
    }

    private void iBAttach_Click( object sender, EventArgs e )
    {

    }

    private void toolStripBtn_Load_Click( object sender, EventArgs e )
    {
      try
      {
        //if (!DocValid())
        //{
        //  return;
        //}
        OpenFileDialog oFileDialog1 = new OpenFileDialog();

        oFileDialog1.Title = "Open Image File";
        oFileDialog1.InitialDirectory = "C:\\temp";     // To be replaced with actual path get from Db with respect to user
        oFileDialog1.Filter = "All files (*.*)|*.*|Jpeg files (*.jpg)|*.jpg|PNG files (*.png)|*.png";
        oFileDialog1.FilterIndex = 2;
        oFileDialog1.RestoreDirectory = true;

        if (oFileDialog1.ShowDialog() == DialogResult.OK)
        {
          string imgPath = oFileDialog1.FileName;
          iBAttach.Image = Image.FromFile(imgPath);
          string lImageName = oFileDialog1.Title.ToString();   //"";

          FileInfo fI = new FileInfo(imgPath);
          fImagePath = fI.FullName.ToString();
          fImageName = fI.Name.ToString();
          fImageExt = fI.Extension.ToString();
          if ((fI.Length / 1024) <= 1024)
          {
            fImageSize = (fI.Length / 1024).ToString() + "K";
          }
          else
          {
            fImageSize = (fI.Length / 1024 / 1024).ToString() + "M";
          }

          fIsNewImageLoaded = true;
          //ImageInfoData(true);
        } // End if

      }
      catch (Exception ex)
      {
        MessageBox.Show("Load Image: " + ex.Message, lblFormTitle.Text.ToString());
      }

    }

    private void toolStripBtn_Save_Click( object sender, EventArgs e )
    {
      SaveImage();
    }

    private void toolStripBtn_Retrieve_Click( object sender, EventArgs e )
    {
      try
      {
        //if (!DocValid())
        //{
        //  return;
        //}
        //========================================================================================
        SqlConnection CN = new SqlConnection(clsGVar.ConString1);
        //Initialize SQL adapter.
        string lSQL = "";
        lSQL = "select ";
        switch ( Convert.ToInt16( cboImageSize.SelectedValue.ToString()) )
        {
          case 0 :
            {
              lSQL += " image_small";
              break;
            }
          case 1:
            {
              lSQL += " image_medium";
              break;
            }
          case 2:
            {
              lSQL += " image_large";
              break;
            }
          case 3:
            {
              lSQL += " image_screen";
              break;
            }
          case 4:
            {
              lSQL += " image_other";
              break;
            }
          case 5:
            {
              lSQL += " image_default";
              break;
            }

          default:
            break;
        }

        lSQL += " as selected_image ";
        lSQL += " from coco ";
        lSQL += " where ";
        lSQL += " coco_id = " + cboCompany.SelectedValue.ToString();
        lSQL += " AND coco_pid = " + cboGroup.SelectedValue.ToString();
        
        //
        SqlDataAdapter ADAP = new SqlDataAdapter(lSQL, CN);
        //Initialize Dataset.
        DataSet DS = new DataSet();
        //Fill dataset with ImagesStore table.
        ADAP.Fill(DS, "selected_image");
        int lRecCount = DS.Tables[0].Rows.Count;
        if (lRecCount == 0)
        {
          MessageBox.Show("Record Not found, image to retrieve.", lblFormTitle.Text.ToString());
          return;
        }
        //fLoadingImg = true;
        DataRow dRow;
        //                       byteArrayToImage((byte[])DS.Tables[0].Rows[1]["picture"])
        //
        //dGvAttach.AllowUserToAddRows = false;
        //dGvAttach.RowTemplate.Height = 70;

        //for (int i = 0; i < DS.Tables[0].Rows.Count; i++)
        //{
        //  dRow = DS.Tables[0].Rows[i];
        //  dGvAttach.Rows.Add(
        //      dRow.ItemArray.GetValue(0).ToString(),
        //      dRow.ItemArray.GetValue(1).ToString(),
        //    //dRow.ItemArray.GetValue(1)                         
        //    //byteArrayToImage((byte[])DS.Tables[0].Rows[i]["imagedata"])
        //      byteArrayToImage(( byte[] )DS.Tables[0].Rows[i]["attach_img1"]),
        //      dRow.ItemArray.GetValue(3).ToString()

        //  );
        //}
        //fLoadingImg = false;
        //ImageInfoData(true);
        if (DS.Tables[0].Rows[0]["selected_image"] != DBNull.Value)
        {
          iBAttach.Image = byteArrayToImage(( byte[] )DS.Tables[0].Rows[0]["selected_image"]);
          fIsNewImageLoaded = true;
        }
        else
        {
          iBAttach.Image = TLERP.Properties.Resources.BaBa_Attach_bg_small;
          fIsNewImageLoaded = false;
          MessageBox.Show("Record found, but no image to retrieve.", lblFormTitle.Text.ToString());
          return;
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show("Exception Retrieve Images: " + ex.Message, "Image: " + lblFormTitle.Text.ToString());
      }

    }

    private void cboImageSize_SelectedIndexChanged( object sender, EventArgs e )
    {
      if (!fIsFormLoading)
      {
        ShowImageText();
        iBAttach.Image = TLERP.Properties.Resources.BaBa_Attach_bg_small;
        fIsNewImageLoaded = false;
      }
    }
    //
    private void ShowImageText()
    {
      if (fIsFormLoading || cboImageSize.Items.Count < 1)
      {
        return;
      }
      switch (Convert.ToInt16( cboImageSize.SelectedValue.ToString() ) )
      {
        case 0:
          {
            lblImageSize.Text = "Small: Company Logo for: Voucher, Document, Invoice, Bill etc.";
            break;
          }
        case 1:
          {
            lblImageSize.Text = "Medium: Company Logo for: Printed reports, Statement, Financial Reports etc";
            break;
          }
        case 2:
          {
            lblImageSize.Text = "large: Company Logo or Picture for: Printed reports, Statement, Financial Reports or specific reports etc";
            break;
          }
        case 3:
          {
            lblImageSize.Text = "Screen: Company Logo or Image to display on screen.";
            break;
          }
        case 4:
          {
            lblImageSize.Text = "Other: User define for specific reports";
            break;
          }
        case 5:
          {
            lblImageSize.Text = "Default: Usually an Image with only . 'dot' for by pass logo for printer economy or any other purpose";
            break;
          }

        default:
          break;
      }
    }

    private void toolStripBtn_Actual_Click( object sender, EventArgs e )
    {
      iBAttach.ActualSize();
    }

    private void toolStripBtn_ZoomIn_Click( object sender, EventArgs e )
    {
      iBAttach.ZoomIn();
    }

    private void toolStripBtn_ZoomOut_Click( object sender, EventArgs e )
    {
      iBAttach.ZoomOut();
    }

    private void cboCompany_SelectedIndexChanged( object sender, EventArgs e )
    {
      if (!fIsFormLoading)
      {
        iBAttach.Image = TLERP.Properties.Resources.BaBa_Attach_bg_small;
        fIsNewImageLoaded = false;
      }
    }

    private void toolStripBtn_Delete_Click( object sender, EventArgs e )
    {

    }

    private void button1_Click( object sender, EventArgs e )
    {
      //GetIPAddresses().ForEach(ip => Console.WriteLine(ip));
      var abc = GetIPAddresses();
      //var name = Console.ReadLine();
      string aaa = string.Empty;
      int i = 0;
      foreach (string item in abc)
      {

        aaa += item + " <> ";
        i++;
      }
    }
    //using System.Linq;
    //using System.Net;
    static List<string> GetIPAddresses()
    {
      return Dns.GetHostAddresses(Dns.GetHostName()).Select(ipAddress => ipAddress.ToString()).ToList<string>();
    }

  }
}
