using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;
using System.Data;
using MySql.Data.MySqlClient;
using LibClassTipi;

namespace FourneeDurtaloise
{
    /// <summary>
    /// Description résumée de MonImage
    /// </summary>
    public class MonImage : IHttpHandler
    {
        private MyCo NewCo;
        private DataSet dsGalerie = new DataSet();
        private Image IMG;
        public void ProcessRequest(HttpContext context)
        {
            NewCo = new MyCo();

            HttpRequest httpRequest = context.Request;
            //Dim IMG_sortie As Bitmap
            MemoryStream ms;
            //si dans la requête http il y a "LOGO_SITE"
            if (httpRequest["IMG"] != null)
            {
                bool verif = true;
                string id = "";
                string num = "";
                foreach (char c in httpRequest["IMG"].ToString())
                {
                    if (c == '-')
                    {
                        verif = false;
                    }
                    if (verif)
                    {
                        id += c;
                    }
                    if (c != '-' && verif == false)
                    {
                        num += c;
                    }
                }
                if (verif)
                {
                    NewCo.Select("t_produit", "id_produit = " + Convert.ToInt32(httpRequest["IMG"]), ref dsGalerie);
                    try
                    {
                        byte[] data = (byte[])dsGalerie.Tables[0].Rows[0].ItemArray[3];
                        ms = new MemoryStream(data);
                        //on instencie un flux de mémoire que l'on paramètre avec le logo du site
                        //IMG = Bitmap.FromStream(ms)
                        //format image en .png
                        context.Response.ContentType = "image/JPG";
                        //IMG.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                        //on ajoute dans le flux de mémoire, le flux sortant
                        ms.WriteTo(context.Response.OutputStream);
                        //on ferme le flux de mémoire
                        ms.Dispose();
                    }
                    catch
                    {
                        IMG = Properties.Resources.SansImageProduit;
                        ms = new MemoryStream(ImageToByteArray(IMG));
                        context.Response.ContentType = "image/JPG";
                        ms.WriteTo(context.Response.OutputStream);
                        ms.Dispose();
                    }
                }
                else
                {
                    try
                    {
                        NewCo.Select("t_images_produit", "fk_id_produit = " + Convert.ToInt32(id), ref dsGalerie);
                        if (dsGalerie != null)
                        {
                            foreach (DataRow dr in dsGalerie.Tables[0].Rows)
                            {
                                if (Convert.ToInt32(num) == Convert.ToInt32(dr.ItemArray[2]))
                                {
                                    byte[] data = (byte[])dr.ItemArray[1];
                                    ms = new MemoryStream(data);
                                    //on instencie un flux de mémoire que l'on paramètre avec le logo du site
                                    //IMG = Bitmap.FromStream(ms)
                                    //format image en .png
                                    context.Response.ContentType = "image/JPG";
                                    //IMG.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                                    //on ajoute dans le flux de mémoire, le flux sortant
                                    ms.WriteTo(context.Response.OutputStream);
                                    //on ferme le flux de mémoire
                                    ms.Dispose();
                                }
                            }
                        }
                        else
                        {
                            IMG = Properties.Resources.SansImageProduit;
                            ms = new MemoryStream(ImageToByteArray(IMG));
                            context.Response.ContentType = "image/JPG";
                            ms.WriteTo(context.Response.OutputStream);
                            ms.Dispose();
                        }
                    }
                    catch
                    {
                        IMG = Properties.Resources.SansImageProduit;
                        ms = new MemoryStream(ImageToByteArray(IMG));
                        context.Response.ContentType = "image/JPG";
                        ms.WriteTo(context.Response.OutputStream);
                        ms.Dispose();
                    }
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public byte[] ImageToByteArray(Image img)
        {
            MemoryStream stream = new MemoryStream();
            img.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            return stream.ToArray();
        }
    }
}