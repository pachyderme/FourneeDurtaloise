<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="FourneeDurtaloise._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <title>Fournée Durtaloise</title>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
    <script src="SCRIPT/Load.js"></script>
    <script src="SCRIPT/Menu.js"></script>
    <script src="SCRIPT/AJAX/AjaxTraitement.js"></script>
    <script src="SCRIPT/ActionControls.js"></script>
    <link href="CSS/StyleDefault.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="CSS/FONTS/font-awesome-4.2.0/css/font-awesome.min.css" />
    <link rel="stylesheet" type="text/css" href="CSS/checkout-boxes.css" />
    <link rel="stylesheet" href="CSS/jquery.mThumbnailScroller.css"/>
</head>
<body>
    <div id="preloader">
        <div id="status">&nbsp;</div>
    </div>
    <form id="form1" runat="server">
        <div class="site-container">
            <div class="site-pusher">
                <div class="btn-menu">
                    <button class="c-hamburger c-hamburger--htx">
                        <span>toggle menu</span>
                    </button>
                </div>
                <div id="TitrePage">
                    <h1>Boulangerie Vauchelet</h1>
                    <h2>Fournée Durtaloise</h2>
                </div>

                <div id="Search" class="is-no-active-search">
                    <div id="IconSearch"></div>
                    <asp:TextBox ID="TbSearch" runat="server" TextMode="Search" ForeColor="#F0F0F0"></asp:TextBox>
                </div>
                <p id="CatProd">Nos Produits</p>
                <div class="checkout">
                    <div class="checkout-grid">
                        <div class="checkout-grid__item">
                            <img src="IMG/cake.png" alt="Shirt" /><h4>Patisserie 1</h4>
                            <span class="price">19.90€</span>
                            <button class="checkout-grid__item-remove"><i class="icon fa fa-close"></i></button>
                        </div>
                        <div class="checkout-grid__item">
                            <img src="IMG/cake.png" alt="Shirt" /><h4>Patisserie 1</h4>
                            <span class="price">19.90€</span>
                            <button class="checkout-grid__item-remove"><i class="icon fa fa-close"></i></button>
                        </div>
                        <div class="checkout-grid__item">
                            <img src="IMG/cake.png" alt="Shirt" /><h4>Viennoiserie 2</h4>
                            <span class="price">29.90€</span>
                            <button class="checkout-grid__item-remove"><i class="icon fa fa-close"></i></button>
                        </div>
                        <div class="checkout-grid__item checkout-grid__item--summary">
                            <button class="checkout__close checkout__cancel" onclick="return false;"><i class="icon fa fa-close"></i></button>
                            <div class="checkout__total">200€</div>
                            <button class="checkout__option checkout__option--loud" onclick="return false;">Commander</button>
                            <button class="checkout__option checkout__option--silent checkout__cancel" onclick="return false;">Continuer sur le site <i class="fa fa-angle-right"></i></button>
                            <a class="checkout__button" href="#">
                                <!-- Fallback location -->
                                <span class="checkout__text">
                                    <svg class="checkout__icon" width="30px" height="30px" viewBox="0 0 35 35">
                                        <path d="M33.623,8.004c-0.185-0.268-0.486-0.434-0.812-0.447L12.573,6.685c-0.581-0.025-1.066,0.423-1.091,1.001 c-0.025,0.578,0.423,1.065,1.001,1.091L31.35,9.589l-3.709,11.575H11.131L8.149,4.924c-0.065-0.355-0.31-0.652-0.646-0.785 L2.618,2.22C2.079,2.01,1.472,2.274,1.26,2.812s0.053,1.146 0.591,1.357l4.343,1.706L9.23,22.4c0.092,0.497,0.524,0.857,1.03,0.857 h0.504l-1.15,3.193c-0.096,0.268-0.057,0.565,0.108,0.798c0.163,0.232,0.429,0.37,0.713,0.37h0.807 c-0.5,0.556-0.807,1.288-0.807,2.093c0,1.732,1.409,3.141,3.14,3.141c1.732,0,3.141-1.408,3.141-3.141c0-0.805-0.307-1.537-0.807-2.093h6.847c-0.5,0.556-0.806,1.288-0.806,2.093c0,1.732,1.407,3.141,3.14,3.141 c1.731,0,3.14-1.408,3.14-3.141c0-0.805-0.307-1.537-0.806-2.093h0.98c0.482,0,0.872-0.391,0.872-0.872s-0.39-0.873-0.872-0.873 H11.675l0.942-2.617h15.786c0.455,0,0.857-0.294,0.996-0.727l4.362-13.608C33.862,8.612,33.811,8.272,33.623,8.004z M13.574,31.108c-0.769,0-1.395-0.626-1.395-1.396s0.626-1.396,1.395-1.396c0.77,0,1.396,0.626,1.396,1.396S14.344,31.108,13.574,31.108z M25.089,31.108c-0.771,0-1.396 0.626-1.396-1.396s0.626-1.396,1.396-1.396c0.77,0,1.396,0.626,1.396,1.396 S25.858,31.108,25.089,31.108z" />
                                    </svg>
                                </span>
                            </a>
                        </div>
                        <div class="checkout-grid__item">
                            <img src="IMG/cake.png" alt="Shirt" /><h4>Pain 1</h4>
                            <span class="price">49.90€</span>
                            <button class="checkout-grid__item-remove"><i class="icon fa fa-close"></i></button>
                        </div>
                        <div class="checkout-grid__item">
                            <img src="IMG/cake.png" alt="Shirt" /><h4>Pain 3</h4>
                            <span class="price">9.90€</span>
                            <button class="checkout-grid__item-remove"><i class="icon fa fa-close"></i></button>
                        </div>
                        <div class="checkout-grid__item">
                            <img src="IMG/cake.png" alt="Shirt" /><h4>Patisserie 5</h4>
                            <span class="price">59.90€</span>
                            <button class="checkout-grid__item-remove"><i class="icon fa fa-close"></i></button>
                        </div>
                        <div class="checkout-grid__item">
                            <img src="IMG/cake.png" alt="Shirt" /><h4>Viennoiserie 4</h4>
                            <span class="price">29.90€</span>
                            <button class="checkout-grid__item-remove"><i class="icon fa fa-close"></i></button>
                        </div>
                    </div>
                </div>
                <div id="Content" runat="server">
                </div>
                <div class="site-content" id="content"></div>
                <div class="site-cache" id="site-cache"></div>
            </div>
        </div>
        <!-- /checkout -->
        <div id="RightContent" class="site-pusher">
            <div id="SelectionContent">
                <h2>Notre Sélection</h2>
                <div id="SelectionProduit">
                    <div id="content-1">
                        <ul id="ul_content_1" runat="server">
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <div id="ShopContent" class="site-pusher">
            <div id="Shop">
                <p>Votre Panier</p>
                <div>
                    <div id="Article">
                        <p id="IconArt"></p>
                        <p id="TextArt">3 Articles</p>
                    </div>
                    <div id="Price">
                        <p id="IconPrice"></p>
                        <p id="TextPrice">24€</p>
                    </div>
                </div>
            </div>
            <div id="Commande">
                <p>Voir ma Commande</p>
            </div>
        </div>
        <div class="menu site-pusher">
            <div class="titre-menu">
                <p>Menu</p>
            </div>
            <div class="div-btn-cat-site">
                <asp:Button ID="btnProduitAll" CssClass="btn-cat-site btn-menu-cat" runat="server" Text="Toutes les créations" OnClientClick="return false;" />
                <div id="CategorieProduitMenu" runat="server"></div>
                <asp:Button ID="btnHoraires" CssClass="btn-cat-site grey btn-menu-cat" runat="server" Text="Horaires" OnClientClick="return false;" Style="background-color: #d78977" />
                <asp:Button ID="btnQui" CssClass="btn-cat-site " runat="server" Text="Qui Sommes-nous ?" OnClientClick="return false;" />
                <asp:Button ID="btnContact" CssClass="btn-cat-site grey" runat="server" Text="Contact" OnClientClick="return false;" />
            </div>
        </div>
    </form>
    <script src="SCRIPT/MenuSuite.js"></script>
    <script src="SCRIPT/classie.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="SCRIPT/jquery.mThumbnailScroller.js"></script>
    
    <script>
        (function () {
            [].slice.call(document.querySelectorAll('.checkout')).forEach(function (el) {
                var openCtrl = el.querySelector('.checkout__button'),
                    closeCtrls = el.querySelectorAll('.checkout__cancel'),
                    checkout = document.getElementsByClassName('checkout');

                openCtrl.addEventListener('click', function (ev) {
                    ev.preventDefault();
                    classie.add(el, 'checkout--active');
                    for (var i = 0; i < checkout.length; i++) {
                        checkout[i].style.zIndex = 2;
                        checkout[i].style.width = "100%";
                        checkout[i].style.height = "100%";
                    }
                });

                [].slice.call(closeCtrls).forEach(function (ctrl) {
                    ctrl.addEventListener('click', function () {
                        for (var i = 0; i < checkout.length; i++) {
                            checkout[i].style.zIndex = 0;
                            checkout[i].style.width = "auto";
                            checkout[i].style.height = "auto";
                        }
                        classie.remove(el, 'checkout--active');
                    });
                });
            });
        })();
    </script>
    <script>
		(function($){
			$(window).load(function(){
				
				$("#content-1").mThumbnailScroller({
					axis:"y",
					type:"hover-precise"
				});				
			});
		})(jQuery);
	</script>
</body>
</html>
