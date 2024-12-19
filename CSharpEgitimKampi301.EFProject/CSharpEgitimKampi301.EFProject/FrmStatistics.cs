using DevExpress.Utils.VisualEffects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
        EgitimCampiEfTravelDbEntities db = new EgitimCampiEfTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            #region Total Number of Location
            lblTotalLocation.Text = db.Tbl_Location.Count().ToString();
            #endregion

            #region Total Number of Capacity
            lblTotalCapacity.Text = db.Tbl_Location.Sum(x => x.LocationCapacity).ToString();
            #endregion

            #region Total Number of Guide
            lblTotalGuide.Text = db.Tbl_Guide.Count().ToString();
            #endregion

            #region Average Number of Capacity
            lblAverageCapacity.Text = db.Tbl_Location.Average(x => x.LocationCapacity).ToString();
            #endregion

            #region Average Price of Tour
            decimal avgLocationPrice = (decimal)db.Tbl_Location.Average(x => x.LocationPrice);
            lblAverageTourPrice.Text = Math.Round(avgLocationPrice, 2).ToString();
            #endregion

            #region Added Last Country
            int lastCountryId = db.Tbl_Location.Max(x => x.LocationId);
            lblAddedLastCountry.Text = db.Tbl_Location.Where(x => x.LocationId == lastCountryId).Select(y => y.LocationCountry).FirstOrDefault();
            #endregion

            #region Amsterdam Tour Capacity
            lblCityTourCapacity.Text = db.Tbl_Location.Where(x => x.LocationCity == "Amsterdam").Select(y => y.LocationCapacity).FirstOrDefault().ToString();
            #endregion

            #region Average Turkey Tour Capacity
            lblCountryTourAverageCapacity.Text = db.Tbl_Location.Where(x => x.LocationCountry == "Turkey").Average(y => y.LocationCapacity).ToString();
            #endregion

            #region Travel Guide of Rome
            var romeGuideId=db.Tbl_Location.Where(x=>x.LocationCity=="Rome").Select(y => y.GuideId).FirstOrDefault();
            lblCityTravelGuide.Text=db.Tbl_Guide.Where(x=>x.GuideId==romeGuideId).Select(y=>y.GuideName + " " + y.GuideSurname).FirstOrDefault();
            #endregion

            #region Most Capaciy Tour
            var maxCapacity = db.Tbl_Location.Max(x => x.LocationCapacity);
            lblMostCapacityTour.Text=db.Tbl_Location.Where(x=>x.LocationCapacity==maxCapacity).Select(y=>y.LocationCity).FirstOrDefault().ToString();
            #endregion

            #region Most Expensive Tour
            decimal expensiveTour=(decimal)db.Tbl_Location.Max(x=>x.LocationPrice);
            lblMostExpensiveTour.Text = db.Tbl_Location.Where(x => x.LocationPrice == expensiveTour).Select(y=>y.LocationCity).FirstOrDefault();
            #endregion

            #region Best Selling Guide
            var maxGuideId=db.Tbl_Location.Max(x=>x.GuideId);
            lblBestSellingGuide.Text=db.Tbl_Guide.Where(x=>x.GuideId==maxGuideId).Select(y=>y.GuideName + " " + y.GuideSurname).FirstOrDefault();
            #endregion

        }


    }
}
