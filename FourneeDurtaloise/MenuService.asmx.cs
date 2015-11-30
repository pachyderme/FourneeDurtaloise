using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using LibClassTipi;

namespace FourneeDurtaloise
{
    /// <summary>
    /// Description résumée de MenuService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    [System.Web.Script.Services.ScriptService]
    public class MenuService : System.Web.Services.WebService
    {
        //[WebMethod]
        //public string RecupProduitCat(List<string> aData)
        //{
        //    DataSet DsJson = new DataSet();
        //    MyCo NewCo = new MyCo();
        //    NewCo.SelectProduitCategorieDix(aData[0], ref DsJson);
        //    return RenvoitHTMLProduit(DsJson.Tables[0]);
        //}  
        //[WebMethod]
        //public string RecupProduitAll(List<string> aData)
        //{
        //    DataSet DsJson = new DataSet();
        //    MyCo NewCo = new MyCo();
        //    NewCo.SelectProduitDix(ref DsJson, Convert.ToInt32(aData[0]));
        //    return RenvoitHTMLProduit(DsJson.Tables[0]);
        //}
        [WebMethod]
        public string RecupProduitCatDix(List<string> aData)
        {
            DataSet DsJson = new DataSet();
            MyCo NewCo = new MyCo();
            try {             
                     NewCo.SelectProduitCategorieDix(ref DsJson,Convert.ToInt32(aData[0]), Convert.ToInt32(aData[1]));               
                }
            catch {
                try
                {
                    NewCo.SelectIdCategorie(ref DsJson, aData[1].ToString());
                    NewCo.SelectProduitCategorieDix(ref DsJson, Convert.ToInt32(aData[0]), Convert.ToInt32(DsJson.Tables[0].Rows[0].ItemArray[0]));
                }
                catch { DsJson = null; }
            }
            if (DsJson != null)
            {
                return RenvoitHTMLProduit(DsJson.Tables[0]);
            }
            else
            {
                return "";
            }
            
        }
        [WebMethod]
        public string RecupProduitDix(List<string> aData)
        {
            DataSet DsJson = new DataSet();
            MyCo NewCo = new MyCo();          
            try
            {
                NewCo.SelectProduitDix(ref DsJson, Convert.ToInt32(aData[0]));
            }
            catch
            {
                try
                {
                    NewCo.SelectIdProduit(ref DsJson, aData[0].ToString());
                    NewCo.SelectProduitDix(ref DsJson, Convert.ToInt32(DsJson.Tables[0].Rows[0].ItemArray[0]));
                }
                catch { DsJson = null; }               
            }
            if(DsJson != null)
            {
                return RenvoitHTMLProduit(DsJson.Tables[0]);
            }
            else
            {
                return "";
            }
            
        }
        [WebMethod]
        public int ModifLikeProduit(List<string> aData)
        {
            DataSet DsJson = new DataSet();
            MyCo NewCo = new MyCo();
            NewCo.UpdateLikeProduit(aData.IndexOf(aData.Last()).ToString(),aData.Last(),ref DsJson);
            return aData.IndexOf(aData.Last());
        }
        [WebMethod]
        public string RecupHoraires(List<string> aData)
        {
            DataSet DsJson = new DataSet();
            MyCo NewCo = new MyCo();
            NewCo.SelectHorairesAll(ref DsJson);
            return RenvoitHTMLHoraires(DsJson.Tables[0]);
        }
        public string RenvoitHTMLProduit(DataTable DtJson)
        {
            string strHtml = "";
            if (DtJson != null) { 
                
            foreach (DataRow dr in DtJson.Rows)
            {
                strHtml += "<div class='Produit'><div class='ImageProduit' style='background-image:url(" + "MonImage.ashx?IMG=" + dr.ItemArray[0].ToString() + ");background-size:cover;background-position:center;'></div><div class='DescriptionProduit'><p class='TitreProduit'>" + dr.ItemArray[1].ToString() + "</p><p class='TextProduit'>" + dr.ItemArray[2].ToString() + "</p></div><div class='Control'><ul><li class='ControlAdLi'><a class='ControlAd icon'></a></li><li class='ControlPictureLi'><a class='ControlPicture icon'></a></li><li class='ControlShareLi'><a class='ControlShare icon'></a></li><li class='ControlLikeLi'><a class='ControlLike icon'></a></li><span class='SpanLike'>" + dr.ItemArray[4].ToString() + "</span></ul></div><div class='Picture'><img src = 'IMG/pati1.jpg' alt='Patisserie' /><img src = 'IMG/pati1.jpg' alt='Patisserie' /><img src = 'IMG/pati1.jpg' alt='Patisserie' /></div></div>";
            } }
            return strHtml;
        }
        public string RenvoitHTMLHoraires(DataTable DtJson)
        {
            string strHtml = "<table class='tg'> ";
            foreach (DataRow dr in DtJson.Rows)
            {
                strHtml += "<tr><th class='tg-baqh' colspan='8'>"+dr.ItemArray[31].ToString()+"</th></tr> <tr><td class='tg-baqh'>Créneaux / Jours</td><td class='tg-baqh'>Lundi</td><td class='tg-baqh'>Mardi</td> <td class='tg-baqh'>Mercredi</td><td class='tg-baqh'>Jeudi</td>  <td class='tg-baqh'>Vendredi</td>  <td class='tg-baqh'>Samedi</td>  <td class='tg-yw4l'>Dimanche</td></tr> <tr>  <td class='tg-baqh'>Début de matinée</td>  <td class='tg-baqh'>"+dr.ItemArray[1].ToString()+ "</td>  <td class='tg-baqh'>" + dr.ItemArray[5].ToString() + "</td>  <td class='tg-baqh'>" + dr.ItemArray[9].ToString() + "</td>  <td class='tg-baqh'>" + dr.ItemArray[13].ToString() + "</td>  <td class='tg-baqh'>" + dr.ItemArray[17].ToString() + "</td>  <td class='tg-baqh'>" + dr.ItemArray[21].ToString() + "</td>  <td class='tg-yw4l'>" + dr.ItemArray[25].ToString() + "</td> </tr> <tr>   <td class='tg-baqh'>Fin de matinée</td>   <td class='tg-baqh'>" + dr.ItemArray[2].ToString() + "</td>   <td class='tg-baqh'>" + dr.ItemArray[6].ToString() + "</td>   <td class='tg-baqh'>" + dr.ItemArray[10].ToString() + "</td>   <td class='tg-baqh'>" + dr.ItemArray[14].ToString() + "</td>   <td class='tg-baqh'>" + dr.ItemArray[18].ToString() + "</td>   <td class='tg-baqh'>" + dr.ItemArray[22].ToString() + "</td>   <td class='tg-yw4l'>" + dr.ItemArray[26].ToString() + "</td> </tr> <tr>   <td class='tg-baqh'>Début de soirée</td>   <td class='tg-baqh'>" + dr.ItemArray[3].ToString() + "</td>  <td class='tg-baqh'>" + dr.ItemArray[7].ToString() + "</td><td class='tg-baqh'>" + dr.ItemArray[11].ToString() + "</td><td class='tg-baqh'>" + dr.ItemArray[15].ToString() + "</td><td class='tg-baqh'>" + dr.ItemArray[19].ToString() + "</td><td class='tg-baqh'>" + dr.ItemArray[23].ToString() + "</td><td class='tg-yw4l'>" + dr.ItemArray[27].ToString() + "</td></tr><tr><td class='tg-baqh'>Fin de soirée</td><td class='tg-baqh'>" + dr.ItemArray[4].ToString() + "</td><td class='tg-baqh'>" + dr.ItemArray[8].ToString() + "</td><td class='tg-baqh'>" + dr.ItemArray[12].ToString() + "</td><td class='tg-baqh'>" + dr.ItemArray[16].ToString() + "</td><td class='tg-baqh'>" + dr.ItemArray[20].ToString() + "</td><td class='tg-baqh'>" + dr.ItemArray[24].ToString() + "</td><td class='tg-yw4l'>" + dr.ItemArray[28].ToString() + "</td></tr>";
            }
            strHtml += "</table>";
            return strHtml;
        }
    }
}
