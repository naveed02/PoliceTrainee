using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI_Task
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmAccLedger frm = new frmAccLedger();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

            frmCashStat frm = new frmCashStat();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            frmCashStatAll frm = new frmCashStatAll();
            frm.MdiParent = this;
            frm.Show();
        }


        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            frmAccReceive frm = new frmAccReceive();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            frmAccPay frm = new frmAccPay();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            frmRptGrp frm = new frmRptGrp();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            frmPeriodAcc frm = new frmPeriodAcc();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            frmBillRece frm = new frmBillRece();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            frmExpComp frm = new frmExpComp();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            frmCustList frm = new frmCustList();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            frmCustomerDiscountlist frm = new frmCustomerDiscountlist();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            frmSupplierList frm = new frmSupplierList();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            frmAccChart frm = new frmAccChart();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            frmTrailBal frm = new frmTrailBal();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            frm_bill_Wise_Aging_Report frm = new frm_bill_Wise_Aging_Report();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            frmPendingOrd frm = new frmPendingOrd();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            frmPendingCont frm = new frmPendingCont();
            frm.MdiParent = this;
            frm.Show();

        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            frmTrackDetail frm = new frmTrackDetail();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
            frmShoeRok frm = new frmShoeRok();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem25_Click(object sender, EventArgs e)
        {
            frmItemTrans frm = new frmItemTrans();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem26_Click(object sender, EventArgs e)
        {
            frmRptPendingOrd1 frm = new frmRptPendingOrd1();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
            frmOrderLevel frm = new frmOrderLevel();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem29_Click(object sender, EventArgs e)
        {
            frmPeriodProd frm = new frmPeriodProd();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {
            frmRateList frm = new frmRateList();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem33_Click(object sender, EventArgs e)
        {
            frmRptIssue frm = new frmRptIssue();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem31_Click(object sender, EventArgs e)
        {
            frmRptTotalStock frm = new frmRptTotalStock();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem32_Click(object sender, EventArgs e)
        {
            frmRptStock frm = new frmRptStock();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem34_Click(object sender, EventArgs e)
        {
            frmRptGateInwardGRN frm = new frmRptGateInwardGRN();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem35_Click(object sender, EventArgs e)
        {
            frmGateOutwardDlvry frm = new frmGateOutwardDlvry();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem36_Click(object sender, EventArgs e)
        {
            frmOrderStatus frm = new frmOrderStatus();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem37_Click(object sender, EventArgs e)
        {
            frmContractorCharges frm = new frmContractorCharges();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem38_Click(object sender, EventArgs e)
        {
            frmRptMachineProd frm = new frmRptMachineProd();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem39_Click(object sender, EventArgs e)
        {
            frmRptContCharCat frm = new frmRptContCharCat();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem40_Click(object sender, EventArgs e)
        {
            frmProdGrp frm = new frmProdGrp();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem41_Click(object sender, EventArgs e)
        {
            frmRawLoc frm = new frmRawLoc();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem42_Click(object sender, EventArgs e)
        {
            frmSalesReturn frm = new frmSalesReturn();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem43_Click(object sender, EventArgs e)
        {
            frmRptExecutive frm = new frmRptExecutive();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem44_Click(object sender, EventArgs e)
        {
            frmProdPlan frm = new frmProdPlan();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem45_Click(object sender, EventArgs e)
        {
            frmRptDispatch frm = new frmRptDispatch();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem46_Click(object sender, EventArgs e)
        {
            frmPendingOrdBags frm = new frmPendingOrdBags();
            frm.MdiParent = this;
            frm.Show();
        }

        private void journalVoucherRokerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmJournalVoc frm = new frmJournalVoc();
            frm.MdiParent = this;
            frm.Show();
        }

        private void rokerGroupWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRokGrp frm = new frmRokGrp();
            frm.MdiParent = this;
            frm.Show();
        }

        private void xRayReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptXray frm = new frmRptXray();
            frm.MdiParent = this;
            frm.Show();
        }

        private void productionProgressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductionProcess frm = new frmProductionProcess();
            frm.MdiParent = this;
            frm.Show();
        }

        private void orderWiseStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptOrder frm = new frmRptOrder();
            frm.MdiParent = this;
            frm.Show();
        }

        private void contractorProductionProgressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmContractorWiseProdProc frm = new frmContractorWiseProdProc();
            frm.MdiParent = this;
            frm.Show();
        }

        private void contractorProductionProcessChargesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmContractorWiseProdProcCharges frm = new frmContractorWiseProdProcCharges();
            frm.MdiParent = this;
            frm.Show();
        }

        private void backupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBackupData frm = new frmBackupData();
            frm.MdiParent = this;
            frm.Show();
        }

        private void receivable_Payable_Click(object sender, EventArgs e)
        {
            frmAccReceivePay frm = new frmAccReceivePay();
            frm.MdiParent = this;
            frm.Show();
        }

        private void userLoginHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserHistory frm = new frmUserHistory();
            frm.MdiParent = this;
            frm.Show();
        }

        private void userEntryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptUser frm = new frmRptUser();
            frm.MdiParent = this;
            frm.Show();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUser frm = new frmUser();
            frm.MdiParent = this;
            frm.Show();
        }

       

        private void duplicateUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDuplicateUser frm = new frmDuplicateUser();
            frm.MdiParent = this;
            frm.Show();
        }

        private void groupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGrpUser frm = new frmGrpUser();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            dt.GetDateTimeFormats();
        }

        private void servicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmServices frm = new frmServices();
            frm.MdiParent = this;
            frm.Show();
        }

        private void formPrivilegesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrivilages frm = new frmPrivilages();
            frm.MdiParent = this;
            frm.Show();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.MdiParent = this;
            frm.Show();
        }

        private void passwordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPassword frm = new frmPassword();
            frm.MdiParent = this;
            frm.Show();
        }

        private void accountDescriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiscVoc frm = new frmDiscVoc();
            frm.MdiParent = this;
            frm.Show();
        }

        private void demandNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDemandNote frm = new frmDemandNote();
            frm.MdiParent = this;
            frm.Show();
        }

        private void purchaseOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchaseOrder frm = new frmPurchaseOrder();
            frm.MdiParent = this;
            frm.Show();
        }

        private void gateInwordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGateInward frm = new frmGateInward();
            frm.MdiParent = this;
            frm.Show();
        }

        private void goodRecieveNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGdRecNote frm = new frmGdRecNote();
            frm.MdiParent = this;
            frm.Show();
        }

        private void gateOutwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGateOutward frm = new frmGateOutward();
            frm.MdiParent = this;
            frm.Show();
        }

        private void salesGateOutwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSales frm = new frmSales();
            frm.MdiParent = this;
            frm.Show();
        }

        private void gateOutwardDeliveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGateOutwardDlvry frm = new frmGateOutwardDlvry();
            frm.MdiParent = this;
            frm.Show();
        }

        private void itemCoversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmItemConversion frm = new frmItemConversion();
            frm.MdiParent = this;
            frm.Show();
        }

        private void finishItemRecieveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFinishItemRec frm = new frmFinishItemRec();
            frm.MdiParent = this;
            frm.Show();
        }

        private void finishItemRecieveDeptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFinishItemRecFormula frm = new frmFinishItemRecFormula();
            frm.MdiParent = this;
            frm.Show();
        }

        private void claimContractorProductionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClaimFromContractor frm = new frmClaimFromContractor();
            frm.MdiParent = this;
            frm.Show();
        }

        private void issueForRePackingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueRePacking frm = new frmIssueRePacking();
            frm.MdiParent = this;
            frm.Show();
        }

        private void godownToGodownShiftingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGdownToGdownShift frm = new frmGdownToGdownShift();
            frm.MdiParent = this;
            frm.Show();
        }

        private void itemsOpeningBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmItemsOpenBal frm = new frmItemsOpenBal();
            frm.MdiParent = this;
            frm.Show();
        }

        private void itemsOpeningBalanceWIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmItemsOpenBalWIP frm = new frmItemsOpenBalWIP();
            frm.MdiParent = this;
            frm.Show();
        }

        private void stockLevelMaximumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frm frm = new Items_Stock_Level_Detail();
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void issueItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueItems frm = new frmIssueItems();
            frm.MdiParent = this;
            frm.Show();
        }

        private void issueItemsFormulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueItemsFormula frm = new frmIssueItemsFormula();
            frm.MdiParent = this;
            frm.Show();
        }

        private void issueItemBatchWiseDeptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueItemsBatchWise frm = new frmIssueItemsBatchWise();
            frm.MdiParent = this;
            frm.Show();
        }

        private void goodsRecieveNoteReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGdRecNoteReturn frm = new frmGdRecNoteReturn();
            frm.MdiParent = this;
            frm.Show();
        }

        private void issueReturnItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueRetnItems frm = new frmIssueRetnItems();
            frm.MdiParent = this;
            frm.Show(); 
        }

        private void saleOrderEntryQoutationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSaleOdrEntryQout frm = new frmSaleOdrEntryQout();
            frm.MdiParent = this;
            frm.Show(); 
        }

        private void saleOrderEntryServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSaleOdrEntryServ frm = new frmSaleOdrEntryServ();
            frm.MdiParent = this;
            frm.Show();
        }

        private void saleOrderEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSaleOrdEntry frm = new frmSaleOrdEntry();
            frm.MdiParent = this;
            frm.Show();
        }

        private void issueForDeliveryOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueForDlvryOdr frm = new frmIssueForDlvryOdr();
            frm.MdiParent = this;
            frm.Show();
        }

        private void deliveryOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDeliveryOrder frm = new frmDeliveryOrder();
            frm.MdiParent = this;
            frm.Show();
        }

        private void invoiceEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvoiceEntry frm = new frmInvoiceEntry();
            frm.MdiParent = this;
            frm.Show();
        }

        private void invoiceEntrySalesTaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvoiceEntrySales frm = new frmInvoiceEntrySales();
            frm.MdiParent = this;
            frm.Show();
        }

        private void invoiceEntryServiceShoesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvoiceEntryServ frm = new frmInvoiceEntryServ();
            frm.MdiParent = this;
            frm.Show();
        }

        private void invoiceEntryCFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInvoiceEntryCF frm = new frmInvoiceEntryCF();
            frm.MdiParent = this;
            frm.Show();
        }

        private void salesReturnEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalesRtnEntry frm = new frmSalesRtnEntry();
            frm.MdiParent = this;
            frm.Show();
        }

        private void codeReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCodeReplace frm = new frmCodeReplace();
            frm.MdiParent = this;
            frm.Show();
        }

        private void contractorCapacityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmContractorCapacity frm = new frmContractorCapacity();
            frm.MdiParent = this;
            frm.Show();
        }

        private void productionProcedureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductionProcedure frm = new frmProductionProcedure();
            frm.MdiParent = this;
            frm.Show();
        }

        private void productionProgressDept2ndStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductionProgressStatus frm = new frmProductionProgressStatus();
            frm.MdiParent = this;
            frm.Show();
        }

        private void productionProgressDeptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductionProgressDept frm = new frmProductionProgressDept();
            frm.MdiParent = this;
            frm.Show();
        }

        private void formulaDefinitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFormulaDefinition frm = new frmFormulaDefinition();
            frm.MdiParent = this;
            frm.Show();
        }

        private void packFormulaDefinitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPackingFormulaDefinition frm = new frmPackingFormulaDefinition();
            frm.MdiParent = this;
            frm.Show();
        }

        private void groupSizeColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frm frm = new frm_Group_Size_Color();
            //frm.MdiParent = this;
            //frm.Show();

        }

        private void customerWiseDiscountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustDiscList frm = new frmCustDiscList();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mainGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGrpSelect frm = new frmGrpSelect();
            frm.MdiParent = this;
            frm.Show();
        }

        private void productionFormulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductionFormula frm = new frmProductionFormula();
            frm.MdiParent = this;
            frm.Show();
        }

        private void contractorChargesTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmContractorChargesTmp frm = new frmContractorChargesTmp();
            frm.MdiParent = this;
            frm.Show();
        }

        private void venderDescriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVenderDescription frm = new frmVenderDescription();
            frm.MdiParent = this;
            frm.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void customerDescriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmCustomerDescription frm = new frmCustomerDescription();
            frm.MdiParent = this;
            frm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cashRecieptVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCashReceVoc frm = new frmCashReceVoc();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cashPaymentVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCashPayVoc frm = new frmCashPayVoc();
            frm.MdiParent = this;
            frm.Show();
        }

        private void journalVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmJournalVoc frm = new frmJournalVoc();
            frm.MdiParent = this;
            frm.Show();
        }

        private void bankRecieptVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBankReceVoc frm = new frmBankReceVoc();
            frm.MdiParent = this;
            frm.Show();
        }

        private void bankPaymentVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBankPayVoc frm = new frmBankPayVoc();
            frm.MdiParent = this;
            frm.Show();
        }

        private void discountVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiscVoc frm = new frmDiscVoc();
            frm.MdiParent = this;
            frm.Show();
        }

        private void chequeRecieveVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChqReceVoc frm = new frmChqReceVoc();
            frm.MdiParent = this;
            frm.Show();
        }

        private void chequePaymentVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChqPayVoc frm = new frmChqPayVoc();
            frm.MdiParent = this;
            frm.Show();
        }

        private void returnBankRecieveVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRetBankVoc frm = new frmRetBankVoc();
            frm.MdiParent = this;
            frm.Show();
        }

        private void chequwReturnCashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChqRet frm = new frmChqRet();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
