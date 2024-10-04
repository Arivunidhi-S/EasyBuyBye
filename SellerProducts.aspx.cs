using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Adapters;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using System.Globalization;
using System.Collections;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.OleDb;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using Telerik.Web.UI.Calendar;
using System.Text.RegularExpressions;
using System.Data.Common;
using System.Web.Configuration;
using System.Net;
using System.IO;
using System.Reflection;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;


public partial class SellerProducts : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            HttpCookie SellerID = new HttpCookie("SellerID");
            SellerID.Value = Request.QueryString.Get("Param").ToString();
            SellerID.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Add(SellerID);

            HttpCookie SellerName = new HttpCookie("SellerName");
            SellerName.Value = Request.QueryString.Get("Param2").ToString();
            SellerName.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Add(SellerName);

            if (string.IsNullOrEmpty(Request.Cookies["SellerID"].Value.ToString()))
            {
                Response.Redirect("SellerLogin.aspx", false);
            }
            else
            {
                //if (string.IsNullOrEmpty(txtProductDetails.ToolTip.ToString()))
                //{
                //    txtProductDetails.ToolTip = "0";
                //}
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                lblName.Text = textInfo.ToTitleCase(Request.Cookies["SellerName"].Value.ToString());
                if (!IsPostBack)
                {
                    BusinessTier.ddlDataLoad(cboBasicCategories, "BasicCategoryMaster", "BasicCategory", "BasicCategoryID", "BasicCategories");
                    Panel2.Visible = false;
                    Panel3.Enabled = false;
                    DivInsert.Visible = false;
                    DivInfo.Visible = false;
                    //BusinessTier.btnVisible(btnclikrjt1, false);
                    //BusinessTier.btnVisible(btnclikrjt2, false);
                    //BusinessTier.btnVisible(btnclikrjt3, false);
                    //BusinessTier.btnVisible(btnclikrjt4, false);
                    //BusinessTier.btnVisible(btnclikrjt5, false);
                }
                            }
        }
        catch (Exception ex)
        {
            Response.Redirect("SellerLogin.aspx", false);
        }
    }

    //**************************ComboBox**************************//

    protected void cboBasicCategories_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        try
        {
            DataTable dtCategoryItems = new DataTable();
            SqlConnection connMenu = BusinessTier.getConnection();
            connMenu.Open();
            SqlDataReader readerMenu = BusinessTier.getBasicCategoryItems(connMenu, "");
            dtCategoryItems.Load(readerMenu);
            RadComboBox comboBox = (RadComboBox)sender;
            comboBox.Items.Clear();
            foreach (DataRow row in dtCategoryItems.Rows)
            {
                RadComboBoxItem item = new RadComboBoxItem();
                item.Text = row["BasicCategory"].ToString();
                item.Value = row["BasicCategoryID"].ToString();
                comboBox.Items.Add(item);
                item.DataBind();
            }
            BusinessTier.DisposeReader(readerMenu);
            BusinessTier.DisposeConnection(connMenu);

        }
        catch (Exception ex)
        {

            //ShowMessage("Please Select the Installation Name", "Red");
        }

    }

    protected void cboCategory_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        try
        {
            DataTable dtCategoryItems = new DataTable();
            SqlConnection connMenu = BusinessTier.getConnection();
            connMenu.Open();
            SqlDataReader readerMenu = BusinessTier.getCategoryItems(connMenu, cboBasicCategories.SelectedValue.ToString());
            dtCategoryItems.Load(readerMenu);
            RadComboBox comboBox = (RadComboBox)sender;
            comboBox.Items.Clear();
            foreach (DataRow row in dtCategoryItems.Rows)
            {
                RadComboBoxItem item = new RadComboBoxItem();
                item.Text = row["Category"].ToString();
                item.Value = row["CategoryID"].ToString();

                comboBox.Items.Add(item);
                item.DataBind();
            }
            BusinessTier.DisposeReader(readerMenu);
            BusinessTier.DisposeConnection(connMenu);

        }
        catch (Exception ex)
        {

            //ShowMessage("Please Select the Installation Name", "Red");
        }

    }

    protected void cboBasicCategories_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        BusinessTier.ddlSelectedDataLoad(cboCategories, "MasterCategory", "Category", "Categoryid", "Category", "BasicCategoryID", cboBasicCategories.SelectedValue.ToString());
    }

    //*******************************TextBox********************************//

    protected void txtDiscount_OnTextChanged(object sender, EventArgs e)
    {
        try
        {
            lblStatus.Text = string.Empty;
            if (string.IsNullOrEmpty(txtSellingPrice.Text.ToString()))
            {
                txtSellingPrice.Text = "0";
            }
            if (string.IsNullOrEmpty(txtDiscountPrice.Text.ToString()))
            {
                txtDiscountPrice.Text = "0";
            }
            decimal p = 0, r = 0, per = 0;
            p = Convert.ToDecimal(txtSellingPrice.Text.ToString().Trim());
            r = Convert.ToDecimal(txtDiscountPrice.Text.ToString().Trim());
            per = (1 - (r / p)) * 100;//p - ((r / 100) * p);
           // txtDiscount.Text = per.ToString("#,0");
        }
        catch (Exception ex)
        {
            InsertLogAuditTrail(Request.Cookies["SellerID"].Value.ToString(), "SellerProducts", "txtDiscount_OnTextChanged", ex.ToString(), "Audit");
        }
    }

    //**************************Button****************************//

    protected void btnAddProduct_OnClick(object sender, EventArgs e)
    {
        DivInsert.Visible = false;
        DivInfo.Visible = false;
        lblStatus.Text = string.Empty;
        SqlConnection conn = BusinessTier.getConnection();
        conn.Open();
        try
        {
            if (string.IsNullOrEmpty(txtTotalStock.Text.ToString()))
            {
                lblStatus.Text = "Enter TotalStock";
                DivInfo.Visible = true;
                return;
            }

            String path = string.Empty, path1 = string.Empty, imagePath1 = string.Empty, imagePath2 = string.Empty, imagePath3 = string.Empty, imagePath4 = string.Empty, imagePath5 = string.Empty;
            path1 = WebConfigurationManager.AppSettings["WC_ImagePath1"].ToString();
            string filename = txtBrand.Text.ToString() + Request.Cookies["SellerID"].Value.ToString() + txtProductDetails.ToolTip.ToString();
            if (!(string.IsNullOrEmpty(FileImage1.FileName.ToString())))
            {
                string downfile = BusinessTier.PhotoName(FileImage1, filename + "1");
                Image(FileImage1, downfile);
                imagePath1 = path1 + downfile.ToString();
            }
            else
            {
                lblStatus2.Text = "The Image 1 shouldn't be empty";
                DivInfo.Visible = true;
                return;
            }
            if (!(string.IsNullOrEmpty(FileImage2.FileName.ToString())))
            {
                string downfile = BusinessTier.PhotoName(FileImage2, filename + "2");
                Image(FileImage2, downfile);
                imagePath2 = path1 + downfile.ToString();
            }
            if (!(string.IsNullOrEmpty(FileImage3.FileName.ToString())))
            {
                string downfile = BusinessTier.PhotoName(FileImage3, filename + "3");
                Image(FileImage3, downfile);
                imagePath3 = path1 + downfile.ToString();
            }
            if (!(string.IsNullOrEmpty(FileImage4.FileName.ToString())))
            {
                string downfile = BusinessTier.PhotoName(FileImage4, filename + "4");
                Image(FileImage4, downfile);
                imagePath4 = path1 + downfile.ToString();
            }
            if (!(string.IsNullOrEmpty(FileImage5.FileName.ToString())))
            {
                string downfile = BusinessTier.PhotoName(FileImage5, filename + "5");
                Image(FileImage5, downfile);
                imagePath5 = path1 + downfile.ToString();
            }

            int flg = BusinessTier.ProductItem(conn, 1, Convert.ToInt32(txtProductDetails.ToolTip.ToString().Trim()), Convert.ToInt32(txtTotalStock.Text.ToString()), imagePath1.ToString().Trim(), imagePath2.ToString().Trim(), imagePath3.ToString(), imagePath4.ToString(), imagePath5.ToString(), 0, Request.Cookies["SellerID"].Value.ToString(), "N");

            BusinessTier.DisposeConnection(conn);
            if (flg >= 1)
            {
                lblStatus.Text = "Successfully Added Your Product. Now you can add Size and Stock";
                DivInsert.Visible = true;
            }
            Panel3.Enabled = true;
        }
        catch (Exception ex)
        {
            lblStatus2.Text = ex.Message.ToString();
            InsertLogAuditTrail(Request.Cookies["SellerID"].Value.ToString(), "SellerProducts", "btnAddProduct_OnClick", ex.ToString(), "Audit");
            DivInfo.Visible = true;
        }
        finally
        {
            BusinessTier.DisposeConnection(conn);
        }


    }

    protected void BtnLogout_Click(object sender, EventArgs e)
    {
        HttpCookie SellerID = new HttpCookie("SellerID");
        SellerID.Value = string.Empty;
        SellerID.Expires = DateTime.Now.AddDays(1);

        HttpCookie SellerName = new HttpCookie("Name");
        SellerName.Value = string.Empty;
        SellerName.Expires = DateTime.Now.AddDays(1);

        HttpCookie RegistrationType = new HttpCookie("RegistrationType");
        RegistrationType.Value = string.Empty;
        RegistrationType.Expires = DateTime.Now.AddDays(1);

        Response.Cookies.Add(SellerID);
        Response.Cookies.Add(SellerName);
        Response.Cookies.Add(RegistrationType);
        Response.Redirect("SellerLogin.aspx", false);
    }

    protected void btnNext_OnClick(object sender, EventArgs e)
    {
        SqlConnection conn = BusinessTier.getConnection();
        conn.Open();

        DivInsert.Visible = false;
        DivInfo.Visible = false;
        lblStatus.Text = string.Empty;

        try
        {
            if (string.IsNullOrEmpty(cboBasicCategories.Text.ToString().Trim()) || cboBasicCategories.SelectedItem.Text == "--Select BasicCategories--")
            {
                lblStatus2.Text = "Please Choose BasicCategories";
                DivInfo.Visible = true;
                return;
            }
            if (string.IsNullOrEmpty(cboCategories.Text.ToString().Trim()) || cboCategories.SelectedItem.Text == "--Select Category--")
            {
                lblStatus2.Text = "Please Choose Categories";
                DivInfo.Visible = true;
                return;
            }
            if (string.IsNullOrEmpty(txtBrand.Text.ToString()))
            {
                lblStatus2.Text = "Enter Brand";
                DivInfo.Visible = true;
                return;
            }

            if (string.IsNullOrEmpty(txtModel.Text.ToString()))
            {
                lblStatus2.Text = "Enter Model";
                DivInfo.Visible = true;
                return;
            }
            if (string.IsNullOrEmpty(flProductPhoto.FileName.ToString()))
            {
                lblStatus2.Text = "Select Product Photo";
                DivInfo.Visible = true;
                return;
            }
            int disc = 0; decimal discprice = 0;

            if (string.IsNullOrEmpty(txtSellingPrice.Text.ToString()))
            {
                txtSellingPrice.Text = "0";
            }
            if (string.IsNullOrEmpty(txtDiscountPrice.Text.ToString()))
            {
                txtDiscountPrice.Text = "0";
            }
            decimal p = 0, r = 0, per = 0;
            p = Convert.ToDecimal(txtSellingPrice.Text.ToString().Trim());
            r = Convert.ToDecimal(txtDiscountPrice.Text.ToString().Trim());
            per = (1 - (r / p)) * 100;
            disc = Convert.ToInt32(per);
            //if (!(string.IsNullOrEmpty(txtDiscount.Text.ToString())))
            //{
            //    disc = Convert.ToInt32(txtDiscount.Text.ToString());
            //}

            if (!(string.IsNullOrEmpty(txtDiscountPrice.Text.ToString())))
            {
                discprice = Convert.ToDecimal(txtDiscountPrice.Text.ToString());
            }
            else
            {
                discprice = Convert.ToDecimal(txtActualPrice.Text.ToString());
            }

            if (string.IsNullOrEmpty(txtWeight.Text.ToString().Trim()))
            {
                txtWeight.Text = "0";
            }

            decimal ShipCost = 0;
            if (rdShipping.SelectedItem.Text == "Yes")
            {
                ShipCost = 5;
            }

            String path = string.Empty, imagePath = string.Empty, imagePath1 = string.Empty;
            string[] ret = flProductPhoto.FileName.Split('.');
            string downfile = txtBrand.Text.ToString() + Request.Cookies["SellerID"].Value.ToString() + txtModel.Text.ToString() + "." + ret[1].ToString();
            Image(flProductPhoto, downfile.ToString());
            imagePath1 = WebConfigurationManager.AppSettings["WC_ImagePath1"].ToString() + downfile.ToString();
            int flg = BusinessTier.Product(conn, 1, Convert.ToInt32(cboCategories.SelectedValue.ToString().Trim()), txtBrand.Text.ToString().Trim(), txtModel.Text.ToString().Trim(), Convert.ToDecimal(0), disc, discprice, Convert.ToDecimal(txtSellingPrice.Text.ToString().Trim()), ShipCost, imagePath1.ToString(), txtProductDetails.Text.ToString().Trim(), Convert.ToInt32(txtWeight.Text.ToString().Trim()), "", "0", 0, Request.Cookies["SellerID"].Value.ToString(), "N",0,0,0);
            //if (flg >= 1)
            //{
            //    lblStatus.Text = "Successfully Added Products!";
            //    DivInfo.Visible = true;
            //}
            txtProductDetails.ToolTip = BusinessTier.MaxID(conn, "MasterProducts", "ProductID", Request.Cookies["SellerID"].Value.ToString());
            BusinessTier.DisposeConnection(conn);
            DisplayRecord();
            Panel1.Visible = false;
            Panel2.Visible = true;
        }
        catch (Exception ex)
        {
            InsertLogAuditTrail(Request.Cookies["SellerID"].Value.ToString(), "SellerProducts", "btnAddProduct_OnClick", ex.ToString(), "Audit");
        }
        finally
        {
            BusinessTier.DisposeConnection(conn);
        }
    }

    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.PathAndQuery, true);
    }

    //************* Grid **************//

    private void DisplayRecord()
    {
        SqlConnection sqlcon = BusinessTier.getConnection();
        sqlcon.Open();
        SqlDataAdapter Adp = new SqlDataAdapter("select * FROM MasterPricing WHERE Deleted=0 and ProductID='" + txtProductDetails.ToolTip.ToString() + "'", sqlcon);
        DataTable Dt = new DataTable();
        Adp.Fill(Dt);
        grid1.DataSource = Dt;
        grid1.DataBind();
        //return Dt;
        BusinessTier.DisposeConnection(sqlcon);
    }

    protected void lnkEdit_OnClick(Object sender, EventArgs e)
    {
        SqlConnection sqlcon = BusinessTier.getConnection();
        sqlcon.Open();
        try
        {
            LinkButton btn = (LinkButton)sender;
            LinkButton lnkEdit = btn.FindControl("lnkEdit") as LinkButton;
            SqlDataReader rd = BusinessTier.FindDuplicate(sqlcon, "MasterPricing", "PricingID", lnkEdit.ToolTip.ToString());
            if (rd.Read())
            {
                txtSize.Text = rd["ProSize"].ToString();
                txtStock.Text = rd["Stock"].ToString();
                txtSize.ToolTip = rd["PricingID"].ToString();
            }
            BusinessTier.DisposeReader(rd);
            BusinessTier.DisposeConnection(sqlcon);
            btnins_up.Text = "Modify";
        }
        catch (Exception ex)
        {
            BusinessTier.DisposeConnection(sqlcon);
            InsertLogAuditTrail(Request.Cookies["SellerID"].Value.ToString(), "SellerProducts", "btnsubmit_OnClick", ex.ToString(), "Audit");
        }
        finally
        {
            BusinessTier.DisposeConnection(sqlcon);
        }
    }

    protected void btnDelete_Onclick(object sender, EventArgs e)
    {
        DivInsert.Visible = false;
        DivInfo.Visible = false;
        SqlConnection sqlcon = BusinessTier.getConnection();
        sqlcon.Open();
        try
        {
            Button btn = (Button)sender;
            Button btnDelete = btn.FindControl("btnDelete") as Button;
            BusinessTier.DeleteGrid(sqlcon, "MasterPricing", "PricingID", Convert.ToInt32(btnDelete.ToolTip.ToString()), Request.Cookies["SellerID"].Value.ToString());
            DivInsert.Visible = true;
            lblStatus.Text = "Successfully deleted Size and Stock!";
            BusinessTier.DisposeConnection(sqlcon);
            DisplayRecord();
        }
        catch (Exception ex)
        {

            BusinessTier.DisposeConnection(sqlcon);
            InsertLogAuditTrail(Request.Cookies["SellerID"].Value.ToString(), "SellerProducts", "btnsubmit_OnClick", ex.ToString(), "Audit");
        }
        finally
        {
            BusinessTier.DisposeConnection(sqlcon);
        }
    }

    protected void btnins_up_Onclick(object sender, EventArgs e)
    {
        DivInsert.Visible = false;
        DivInfo.Visible = false;
        SqlConnection conn = BusinessTier.getConnection();
        conn.Open();
        try
        {
            if (string.IsNullOrEmpty(txtSize.Text.ToString().Trim()))
            {
                lblStatus2.Text = "Enter Size";
                DivInfo.Visible = true;
                return;
            }
            if (string.IsNullOrEmpty(txtStock.Text.ToString().Trim()))
            {
                lblStatus2.Text = "Enter Stock";
                DivInfo.Visible = true;
                return;
            }
            int flg = 0;
            if (string.IsNullOrEmpty(txtSize.ToolTip.ToString().Trim()))
            {

                flg = BusinessTier.AddStock(conn, 1, Convert.ToInt32(txtProductDetails.ToolTip.ToString()), "", txtSize.Text.ToString().Trim(), txtStock.Text.ToString(), Request.Cookies["SellerID"].Value.ToString(), "N");
                lblStatus.Text = "Successfully Added Size and Stock";
                DivInsert.Visible = true;
            }
            else
            {
                flg = BusinessTier.AddStock(conn, Convert.ToInt32(txtSize.ToolTip.ToString()), Convert.ToInt32(txtProductDetails.ToolTip.ToString()), "", txtSize.Text.ToString().Trim(), txtStock.Text.ToString(), Request.Cookies["SellerID"].Value.ToString(), "U");
                lblStatus.Text = "Successfully Modified Size and Stock";
                DivInsert.Visible = true;
                btnins_up.Text = "Add";
                txtSize.ToolTip = "";
            }
            BusinessTier.DisposeConnection(conn);
            DisplayRecord();
            BusinessTier.Clear(txtSize);
            BusinessTier.Clear(txtStock);
        }
        catch (Exception ex)
        {

            InsertLogAuditTrail(Request.Cookies["SellerID"].Value.ToString(), "btnins_up_Onclick", "SellerProducts", ex.ToString(), "Audit");

        }
        finally
        {
            BusinessTier.DisposeConnection(conn);
        }

    }

    //**********************Function***********************//

    private void InsertLogAuditTrail(string userid, string module, string activity, string result, string flag)
    {
        SqlConnection connLog = BusinessTier.getConnection();
        connLog.Open();
        BusinessTier.InsertLogAuditTrial(connLog, userid, module, activity, result, flag);
        BusinessTier.DisposeConnection(connLog);
    }

    protected void Image2(FileUpload FileUpload1, string ImageName)
    {
        String imgpath = FileUpload1.FileName;
        if (imgpath != null)
        {
            Guid uid = Guid.NewGuid(); //get a unique identifier variable

            string FilePathStr = Server.MapPath("~/") + "web/Products";

            if (!(Directory.Exists(FilePathStr)))
            {
                Directory.CreateDirectory(FilePathStr);
            }

            //string[] ret = FileUpload1.FileName.Split('.');
            //string downfile = cboCategories.Text.ToString() + Session["CustomerID"].ToString().Trim() + txtBrand.Text.ToString() + "." + ret[1].ToString();

            string SaveLocation = "web/Products/" + ImageName.ToString();
            string fileExtention = FileUpload1.PostedFile.ContentType;
            int fileLenght = FileUpload1.PostedFile.ContentLength;
            if (fileExtention == "image/png" || fileExtention == "image/jpeg" || fileExtention == "image/x-png")
            {
                if (fileLenght <= 1048576)
                {
                    System.Drawing.Bitmap bmpUploadedImage = new System.Drawing.Bitmap(FileUpload1.PostedFile.InputStream);

                    System.Drawing.Image objImage = ScaleImage2(bmpUploadedImage, 212);
                    objImage.Save(Server.MapPath(SaveLocation), ImageFormat.Png);
                    lblStatus.ForeColor = Color.Green;
                    lblStatus.Text = "The file has been uploaded.";

                }
            }
        }
    }

    public static System.Drawing.Image ScaleImage2(System.Drawing.Image image, int maxImageHeight)
    {
        var newImage = new Bitmap(212, 212);
        using (var g = Graphics.FromImage(newImage))
        {
            g.DrawImage(image, 0, 0, 212, 212);
        }
        return newImage;
    }

    protected void Image(FileUpload FileUpload1, string ImageName)
    {
        String imgpath = FileUpload1.FileName;
        if (imgpath != null)
        {
            Guid uid = Guid.NewGuid(); //get a unique identifier variable

            string FilePathStr = Server.MapPath("~/") + "web/Products";

            if (!(Directory.Exists(FilePathStr)))
            {
                Directory.CreateDirectory(FilePathStr);
            }

            string SaveLocation = "web/Products/" + ImageName.ToString();
            string fileExtention = FileUpload1.PostedFile.ContentType;
            int fileLenght = FileUpload1.PostedFile.ContentLength;
            if (fileExtention == "image/png" || fileExtention == "image/jpeg" || fileExtention == "image/x-png")
            {
                if (fileLenght <= 1048576)
                {
                    System.Drawing.Bitmap bmpUploadedImage = new System.Drawing.Bitmap(FileUpload1.PostedFile.InputStream);

                    System.Drawing.Image objImage = ScaleImage(bmpUploadedImage, 995);
                    objImage.Save(Server.MapPath(SaveLocation), ImageFormat.Png);
                    lblStatus.ForeColor = Color.Green;
                    lblStatus.Text = "The file has been uploaded.";
                    //Img.ImageUrl = "~/" + SaveLocation;
                }
            }
        }
    }

    public static System.Drawing.Image ScaleImage(System.Drawing.Image image, int maxImageHeight)
    {

        /* we will resize image based on the height/width ratio by passing expected height as parameter. Based on Expected height and current image height, new ratio will be arrived and using the same we will do the resizing of image width. */

        var ratio = (double)maxImageHeight / image.Height;
        var newWidth = (int)(image.Width * ratio);
        var newHeight = (int)(image.Height * ratio);
        var newImage = new Bitmap(newWidth, newHeight);
        using (var g = Graphics.FromImage(newImage))
        {
            g.DrawImage(image, 0, 0, newWidth, newHeight);
        }
        return newImage;
    }

    }