using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using LibClassTipi;

namespace FourneeDurtaloise
{
    public partial class _default : System.Web.UI.Page
    {
        private MyCo NewCo;
        private DataSet dsGalerie = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            NewCo = new MyCo();
            if (IsPostBack == false)
            {
                NewCo.Select("t_produit p", ref dsGalerie);
                TraitementBDD(dsGalerie,0);
                dsGalerie.Reset();
                NewCo.Select("DISTINCT id_categorie,libelle_site_categorie","t_produit", "t_categorie on id_categorie = fk_id_categorie",0, ref dsGalerie);
                TraitementBDD(dsGalerie,1);
                dsGalerie.Reset();
            }
        }
        public void TraitementBDD(DataSet dsGalerie, int unChoix)
        {
            int cpt = 0;
            try
            {
                if(unChoix == 0)
                {
                    foreach (DataRow dr in dsGalerie.Tables[0].Rows)
                    {
                        Content.InnerHtml += "<div class='Produit'><div class='ImageProduit' style='background-image:url(" + "MonImage.ashx?IMG=" + dr.ItemArray[0].ToString() + ");background-size:cover;background-position:center;'></div><div class='DescriptionProduit'><p class='TitreProduit'>" + dr.ItemArray[1].ToString() + "</p><p class='TextProduit'>" + dr.ItemArray[2].ToString() + "</p></div><div class='Control'><ul><li class='ControlAdLi'><a class='ControlAd icon'></a></li><li class='ControlPictureLi'><a class='ControlPicture icon'></a></li><li class='ControlShareLi'><a class='ControlShare icon'></a></li><li class='ControlLikeLi'><a class='ControlLike icon'></a></li><span class='SpanLike'>" + dr.ItemArray[4].ToString() + "</span></ul></div><div class='Picture'><img src = 'IMG/pati1.jpg' alt='Patisserie' /><img src = 'IMG/pati1.jpg' alt='Patisserie' /><img src = 'IMG/pati1.jpg' alt='Patisserie' /></div></div>";
                        if((bool)dr.ItemArray[5])
                        {
                            ul_content_1.InnerHtml += "<li><a href='#'><img class='ProduitSelection' style='background-image:url(" + "MonImage.ashx?IMG=" + dr.ItemArray[0].ToString() + ");background-size:cover;background-position:center;'></img></a></li>";
                        }
                    }
                }
                if(unChoix == 1)
                {
                    foreach (DataRow dr in dsGalerie.Tables[0].Rows)
                    {
                        cpt++;
                        if(cpt%2 != 0)
                        {
                            CategorieProduitMenu.InnerHtml += "<input name='btnProduit" + dr.ItemArray[0].ToString() + "' ID='btnProduit" + dr.ItemArray[0].ToString() + "' Class='btn-cat-site grey btn-menu-cat' runat='server ' value='" + dr.ItemArray[1].ToString() + "' onclick='return false;' type='submit' />";
                        }
                        else
                        {
                            CategorieProduitMenu.InnerHtml += "<input name='btnProduit" + dr.ItemArray[0].ToString() + "' ID='btnProduit" + dr.ItemArray[0].ToString() + "' Class='btn-cat-site btn-menu-cat' runat='server' value='" + dr.ItemArray[1].ToString() + "' onclick='return false;' type='submit' />";
                        }
                        
                    }                    
                }
                
            }
            catch { }
        }
    }
}