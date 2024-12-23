﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_1
{
    public partial class Question2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Image1.ImageUrl = "";
                Label1.Text = "Price will be displayed";
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProduct = DropDownList1.SelectedValue;

            switch (selectedProduct)
            {
                case "1":
                    Image1.ImageUrl = "images/product1.jpg";
                    break;

                case "2":
                    Image1.ImageUrl = "images/product2.jpg";
                    break;

                case "3":
                    Image1.ImageUrl = "images/product3.jpg";
                    break;

                default:
                    Image1.ImageUrl = "";
                    Label1.Text = "Please select a product";
                    break;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string selectedprod = DropDownList1.SelectedValue;
            string price = " ";
            switch (selectedprod)
            {
                case "1":
                    price = "100 rupees";
                    break;
                case "2":
                    price = "200 rupees";
                    break;
                case "3":
                    price = "300 rupees";
                    break;
                default:
                    price = "Please select product";
                    break;



            }
            Label1.Text = "price:" + price;
        }
    }
}