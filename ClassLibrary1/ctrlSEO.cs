using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace ClassLibrary
{
    public class ctrlSEO
    {
        public string ConvertToSearchGoogle(string str, string replace, bool isEnglish)
        {
            str = str.Normalize();
            if (isEnglish)
                str = ConvertToEnglish(str);
            str = ReplaceWordChars(str);
            str = str.Replace("-", " ");
            str = str.Replace("–", " ");
            str = str.Replace("_", " ");
            str = str.Replace("+", " ");
            str = str.Replace("/", " ");
            str = str.Replace("\\", " ");
            str = str.Replace("+", " ");
            str = str.Replace("&", " ");
            str = str.Replace("$", " ");
            str = str.Replace("!", " ");
            str = str.Replace("#", " ");
            str = str.Replace("@", " ");
            str = str.Replace("%", " ");
            str = str.Replace("^", " ");
            str = str.Replace("*", " ");
            str = str.Replace(":", " ");
            str = str.Replace(",", " ");
            str = str.Replace("?", " ");
            str = str.Replace("<", " ");
            str = str.Replace(">", " ");
            str = str.Replace(".", " ");
            str = str.Replace("\'", " ");
            str = str.Replace("\"", " ");
            str = str.Replace(";", " ");
            str = str.Replace("®", " ");
            str = str.Replace("™", " ");
            str = str.Replace("�", " ");
            str = str.Replace(((char)34).ToString(), " ");
            str = str.Replace(((char)39).ToString(), " ");
            string fn = Regex.Replace(str, @"[(\n)(\s+)(\b)(\t)'!@#$%^&*()<>?/|{}~`:;-]", " ");
            str = Regex.Replace(fn, @"\s+", " ");
            str = str.Replace(" ", replace);
            return str;
        }

        public string ReplaceWordChars(string text)
        {
            var s = text;
            // smart single quotes and apostrophe
            s = Regex.Replace(s, "[\u2018|\u2019|\u201A]", " ");
            // smart double quotes
            s = Regex.Replace(s, "[\u201C|\u201D|\u201E]", " ");
            // ellipsis
            s = Regex.Replace(s, "\u2026", " ");
            // dashes
            s = Regex.Replace(s, "[\u2013|\u2014]", "");
            // circumflex
            s = Regex.Replace(s, "\u02C6", " ");
            // open angle bracket
            s = Regex.Replace(s, "\u2039", " ");
            // close angle bracket
            s = Regex.Replace(s, "\u203A", " ");
            // spaces
            s = Regex.Replace(s, "[\u02DC|\u00A0]", " ");
            return s;
        }

        public string ConvertToEnglish(string str)
        {
            str = str.Replace("À", "A");
            str = str.Replace("Á", "A");
            str = str.Replace("Ả", "A");
            str = str.Replace("Ã", "A");
            str = str.Replace("Ạ", "A");

            str = str.Replace("Ă", "A");
            str = str.Replace("Ắ", "A");
            str = str.Replace("Ẳ", "A");
            str = str.Replace("Ẵ", "A");
            str = str.Replace("Ặ", "A");
            str = str.Replace("Ằ", "A");

            str = str.Replace("Â", "A");
            str = str.Replace("Ấ", "A");
            str = str.Replace("Ầ", "A");
            str = str.Replace("Ẩ", "A");
            str = str.Replace("Ẫ", "A");
            str = str.Replace("Ậ", "A");

            str = str.Replace("Đ", "D");
            str = str.Replace("È", "E");
            str = str.Replace("É", "E");
            str = str.Replace("Ẻ", "E");
            str = str.Replace("Ẽ", "E");
            str = str.Replace("Ẹ", "E");

            str = str.Replace("Ê", "E");
            str = str.Replace("Ề", "E");
            str = str.Replace("Ế", "E");
            str = str.Replace("Ể", "E");
            str = str.Replace("Ễ", "E");
            str = str.Replace("Ệ", "E");

            str = str.Replace("Ì", "I");
            str = str.Replace("Í", "I");
            str = str.Replace("Ỉ", "I");
            str = str.Replace("Ĩ", "I");
            str = str.Replace("Ị", "I");

            str = str.Replace("Ò", "O");
            str = str.Replace("Ó", "O");
            str = str.Replace("Ỏ", "O");
            str = str.Replace("Õ", "O");
            str = str.Replace("Ọ", "O");

            str = str.Replace("Ô", "O");
            str = str.Replace("Ồ", "O");
            str = str.Replace("Ố", "O");
            str = str.Replace("Ổ", "O");
            str = str.Replace("Ỗ", "O");
            str = str.Replace("Ộ", "O");

            str = str.Replace("Ơ", "O");
            str = str.Replace("Ờ", "O");
            str = str.Replace("Ớ", "O");
            str = str.Replace("Ở", "O");
            str = str.Replace("Ỡ", "O");
            str = str.Replace("Ợ", "O");

            str = str.Replace("Ù", "U");
            str = str.Replace("Ú", "U");
            str = str.Replace("Ủ", "U");
            str = str.Replace("Ũ", "U");
            str = str.Replace("Ụ", "U");

            str = str.Replace("Ư", "U");
            str = str.Replace("Ừ", "U");
            str = str.Replace("Ứ", "U");
            str = str.Replace("Ử", "U");
            str = str.Replace("Ữ", "U");
            str = str.Replace("Ự", "U");

            str = str.Replace("Ỳ", "Y");
            str = str.Replace("Ý", "Y");
            str = str.Replace("Ỷ", "Y");
            str = str.Replace("Ỹ", "Y");
            str = str.Replace("Ỵ", "Y");

            // LOWER CASE
            str = str.Replace("à", "a");
            str = str.Replace("á", "a");
            str = str.Replace("ả", "a");
            str = str.Replace("ã", "a");
            str = str.Replace("ạ", "a");

            str = str.Replace("â", "a");
            str = str.Replace("ấ", "a");
            str = str.Replace("ầ", "a");
            str = str.Replace("ẩ", "a");
            str = str.Replace("ẫ", "a");
            str = str.Replace("ậ", "a");

            str = str.Replace("ă", "a");
            str = str.Replace("ắ", "a");
            str = str.Replace("ằ", "a");
            str = str.Replace("ẳ", "a");
            str = str.Replace("ẵ", "a");
            str = str.Replace("ặ", "a");

            str = str.Replace("đ", "d");

            str = str.Replace("è", "e");
            str = str.Replace("é", "e");
            str = str.Replace("ẻ", "e");
            str = str.Replace("ẽ", "e");
            str = str.Replace("ẹ", "e");

            str = str.Replace("ê", "e");
            str = str.Replace("ề", "e");
            str = str.Replace("ế", "e");
            str = str.Replace("ể", "e");
            str = str.Replace("ễ", "e");
            str = str.Replace("ệ", "e");
            str = str.Replace("ẽ", "e");

            str = str.Replace("ì", "i");
            str = str.Replace("í", "i");
            str = str.Replace("ỉ", "i");
            str = str.Replace("ĩ", "i");
            str = str.Replace("ị", "i");
            str = str.Replace("ị", "i");

            str = str.Replace("ò", "o");
            str = str.Replace("ó", "o");
            str = str.Replace("ỏ", "o");
            str = str.Replace("õ", "o");
            str = str.Replace("ọ", "o");

            str = str.Replace("ô", "o");
            str = str.Replace("ồ", "o");
            str = str.Replace("ố", "o");
            str = str.Replace("ổ", "o");
            str = str.Replace("ỗ", "o");
            str = str.Replace("ộ", "o");

            str = str.Replace("ơ", "o");
            str = str.Replace("ờ", "o");
            str = str.Replace("ớ", "o");
            str = str.Replace("ở", "o");
            str = str.Replace("ỡ", "o");
            str = str.Replace("ợ", "o");

            str = str.Replace("ù", "u");
            str = str.Replace("ú", "u");
            str = str.Replace("ủ", "u");
            str = str.Replace("ũ", "u");
            str = str.Replace("ụ", "u");

            str = str.Replace("ư", "u");
            str = str.Replace("ừ", "u");
            str = str.Replace("ứ", "u");
            str = str.Replace("ử", "u");
            str = str.Replace("ữ", "u");
            str = str.Replace("ự", "u");

            str = str.Replace("ỳ", "y");
            str = str.Replace("ý", "y");
            str = str.Replace("ỷ", "y");
            str = str.Replace("ỹ", "y");
            str = str.Replace("ỵ", "y");
            return str;
        }





        public string ConvertPageTitle(string str, string replace, bool isEnglish)
        {
            str = str.Normalize();
            str = ReplaceWordChars(str);
            str = str.Replace("-", " ");
            str = str.Replace("+", " ");
            str = str.Replace("/", " ");
            str = str.Replace("\\", " ");
            str = str.Replace("+", " ");
            str = str.Replace("&", " ");
            str = str.Replace("$", " ");
            str = str.Replace("!", " ");
            str = str.Replace("#", " ");
            str = str.Replace("@", " ");
            str = str.Replace("%", " ");
            str = str.Replace("^", " ");
            str = str.Replace("*", " ");
            str = str.Replace(":", " ");
            str = str.Replace(",", " ");
            str = str.Replace("?", " ");
            str = str.Replace("<", " ");
            str = str.Replace(">", " ");
            str = str.Replace(".", " ");
            str = str.Replace("\'", " ");
            str = str.Replace(";", " ");
            str = str.Replace("®", " ");
            str = str.Replace("™", " ");
            str = str.Replace("�", " ");
            string fn = Regex.Replace(str, @"[(\n)(\s+)(\b)(\t)'!@#$%^&*()<>?/|{}~`:;-]", " ");
            str = Regex.Replace(fn, @"\s+", " ").Trim();
            str = str.Replace(" ", replace);
            str = str.Replace(((char)34).ToString(), "&quot;");
            str = str.Replace(((char)39).ToString(), "&quot;");
            return str;
        }


        public string KEYWORD_SEARCH_TERM(string KEYWORD)
        {
            var TERMS = " ";
            try
            {
                if (KEYWORD.StartsWith("\""))
                {
                    TERMS = "\"";
                }
                else if (KEYWORD.StartsWith("[") && KEYWORD.EndsWith("]"))
                {
                    TERMS = "[";
                }
                else if (KEYWORD.StartsWith("~"))
                {
                    TERMS = "~";
                }
                else if (KEYWORD.StartsWith("^"))
                {
                    TERMS = "^";
                }
                else if (KEYWORD.Contains("|") || KEYWORD.ToLower().Contains("or"))
                {
                    TERMS = "|";
                }
                else
                {
                    TERMS = "+";
                }

                //switch (KEYWORD.ToLower())
                //{
                //    case "\"":
                //        //Phrases are enclosed in double quotes. Any embedded quotes may be escaped using \".
                //        //If no field is specified, then the default TEXT field will be used, as with searches for a single term.
                //        //The whole phrase will be tokenized before the search according to the appropriate data dictionary definition(s).
                //        RESULT = KEYWORD.Replace(" ", TERM);
                //        break;
                //    case "=":
                //        //To search for an exact term, prefix the term with "=".
                //        //This ensures the term will not be tokenized.
                //        //If both FTS and ID base search are supported for a specified or implied property,
                //        //then exact matching will be used where possible.
                //        RESULT = KEYWORD.Replace(" ", TERM);
                //        break;
                //    case "[":
                //    case "]":
                //    case "<":
                //    case ">":
                //        //RESULT =Regex.Replace(KEYWORD,"",RegexOptions.IgnoreCase);
                //        break;
                //    case "~":
                //        //To force tokenization and term expansion, prefix the term with "~".
                //        //For a property with both ID and FTS indexes where the ID index is the default, force the use of the FTS index
                //        break;
                //    case "^":
                //        break;
                //    case "+":
                //    case "and":
                //        //"+"	The field, phrase, group, etc, is mandatory (this differs from Google - see "=")
                //        //Single terms, phrases, etc can be combined using "AND" in upper, lower, or mixed case.
                //        break;
                //    case "|":
                //    case "or":
                //        //"|"	The field, phrase, group, etc, is optional; a match increases the score.

                //        //Single terms, phrases, etc can be combined using "OR" in upper, lower, or mixed case.
                //        //If not otherwise specified, the search fragments will be ORed together by default.

                //        //Single terms, phrases, etc can be combined using "NOT" in upper, lower, or mixed case or prefixed with "!" or "-"
                //        break;
                //    case "-":
                //    case "!":
                //        //"-", "!"	The field, phrase, group, etc, must not match
                //        break;
                //    case "not":
                //        //Single terms, phrases, etc can be combined using "NOT" in upper, lower, or mixed case or prefixed with "!" or "-"
                //        break;

                //}
            }
            catch (Exception ex)
            {
            }
            return TERMS;
        }


        public string FULLTEXT_SEARCH(string KEYWORD, string TERM = "+")
        {
            var RESULT = " ";
            try
            {
                TERM = TERM != "" ? TERM : KEYWORD_SEARCH_TERM(KEYWORD);
                switch (TERM.ToLower())
                {
                    case "\"":
                        //Phrases are enclosed in double quotes. Any embedded quotes may be escaped using \".
                        //If no field is specified, then the default TEXT field will be used, as with searches for a single term.
                        //The whole phrase will be tokenized before the search according to the appropriate data dictionary definition(s).
                        RESULT = KEYWORD.Replace(" ", TERM);
                        break;
                    case "=":
                        //To search for an exact term, prefix the term with "=".
                        //This ensures the term will not be tokenized.
                        //If both FTS and ID base search are supported for a specified or implied property,
                        //then exact matching will be used where possible.
                        RESULT = KEYWORD.Replace(" ", TERM);
                        break;
                    case "[":
                    case "]":
                    case "<":
                    case ">":
                        //RESULT =Regex.Replace(KEYWORD,"",RegexOptions.IgnoreCase);
                        break;
                    case "~":
                        RESULT = KEYWORD.Replace(" ", "+");
                        //To force tokenization and term expansion, prefix the term with "~".
                        //For a property with both ID and FTS indexes where the ID index is the default, force the use of the FTS index
                        break;
                    case "^":
                        RESULT = KEYWORD.Replace(" ", TERM);
                        break;
                    case "+":
                    case "and":
                        //"+"	The field, phrase, group, etc, is mandatory (this differs from Google - see "=")
                        //Single terms, phrases, etc can be combined using "AND" in upper, lower, or mixed case.
                        RESULT = KEYWORD.Replace(" ", TERM);
                        break;
                    case "|":
                    case "or":
                        //"|"	The field, phrase, group, etc, is optional; a match increases the score.

                        //Single terms, phrases, etc can be combined using "OR" in upper, lower, or mixed case.
                        //If not otherwise specified, the search fragments will be ORed together by default.

                        //Single terms, phrases, etc can be combined using "NOT" in upper, lower, or mixed case or prefixed with "!" or "-"
                        break;
                    case "-":
                    case "!":
                        RESULT = KEYWORD.Replace(" ", TERM);
                        //"-", "!"	The field, phrase, group, etc, must not match
                        break;
                    case "not":
                        RESULT = KEYWORD.Replace(" ", TERM);
                        //Single terms, phrases, etc can be combined using "NOT" in upper, lower, or mixed case or prefixed with "!" or "-"
                        break;
                }
            }
            catch (Exception ex)
            {
            }
            return RESULT;
        }

        public void PAGE_SEO(Page PAGE, string PAGE_LINK = "", string SITE_NAME = "", string AUTHOR = "",
            string META_TITLE = "", string META_KEYWORD = "", string META_DESCRIPION = "", string NAME_SEO = "",
            string META_IMAGE = "", string PAGE_TYPE = "Ecommerce", string PAGE_ROBOT = "NOODP,index,follow",
            string LOCALE = "vi_VN;en_US", string APPID = "", string WEBSITE_ICON = "")
        {
            string _domain = ConfigurationManager.AppSettings["domain"];
            var CATE_CODE = ConvertToSearchGoogle(NAME_SEO, "-", true);
            //var TITLE = "";
            //var CATE_DESC = "";
            var LINK_SEO = "";
            LINK_SEO = _domain + PAGE_LINK; // + "key-search/?k=" + NAME_SEO
            //meta_httpequiv(PAGE, "utf-8");
            meta_page_icon(PAGE, WEBSITE_ICON);
            PAGE.Title = META_TITLE; // "Kay.vn | tìm với từ khóa:" + NAME_SEO
            PAGE.MetaKeywords = META_KEYWORD != "" ? META_KEYWORD : ""; //yume,chế biến,....
            PAGE.MetaDescription = META_DESCRIPION != "" ? META_DESCRIPION : "";
            //Những thức ăn ngon phù hợp với sức khỏe người già,...
            canonical(PAGE, LINK_SEO); //http://kay.vn/thuc-an-suc-khoe-dinh-duong-cho-moi-lua-tuoi.html
            meta_author(PAGE, AUTHOR); //Kay.vn
            meta_robot(PAGE, PAGE_ROBOT); //NOODP,index,follow
            meta_sitename(PAGE, SITE_NAME); //Kay.vn
            meta_image(PAGE, META_IMAGE);

            #region FACEBOOK

            meta_og_title(PAGE, META_TITLE); //Yume.vn | Thức ăn sức khỏe dinh dưỡng cho mọi lứa tuổi.
            meta_og_type(PAGE, PAGE_TYPE); //Ecommerce|Tin tức|......
            meta_og_description(PAGE, (META_DESCRIPION != "" ? META_DESCRIPION : ""));
            //Những thức ăn ngon phù hợp với sức khỏe người già,...
            meta_og_url(PAGE, LINK_SEO); //http://Kay.vn/pizza
            meta_og_locale(PAGE, LOCALE); //HCM
            meta_og_appid(PAGE, APPID); //1234567484632

            #endregion

            #region TWITTER

            meta_Twitter_Cards_title(PAGE, META_TITLE);
            meta_Twitter_Cards(PAGE, PAGE_TYPE); //Yume.vn | Thức ăn sức khỏe dinh dưỡng cho mọi lứa tuổi.
            meta_Twitter_Cards_description(PAGE, (META_DESCRIPION != "" ? META_DESCRIPION : ""));
            //Những thức ăn ngon phù hợp với sức khỏe người già,...
            meta_Twitter_Cards_image(PAGE, META_IMAGE);
            meta_Twitter_Cards_site(PAGE, SITE_NAME); //Kay.vn
            meta_Twitter_Cards_url(PAGE, LINK_SEO); //http://Kay.vn/pizza
            //meta_og_locale(PAGE, LOCALE);//HCM
            //meta_og_appid(PAGE, APPID);//1234567484632

            #endregion

            //if (CATE_CODE != "" && CATE_CODE != NAME_SEO)
            //{
            //    Response.Status = "301 Moved Permanently";
            //    Response.AddHeader("Location", LINK_SEO);
            //}
        }

        #region META SOCIAL

        #region FACEBOOK META TAG

        /// <summary>
        /// specify the title of the content (object), best 60-90 characters.
        /// </summary>
        /// <param name="_page"></param>
        /// <param name="title"></param>
        public void meta_og_title(Page _page, string title)
        {
            HtmlMeta tagTitle = new HtmlMeta();
            tagTitle.Attributes.Add("property", "og:title");
            tagTitle.Content = title;
            _page.Header.Controls.Add(tagTitle);
        }

        /// <summary>
        /// specify the type of object for your content, it can be: blog, website or article and more.
        /// </summary>
        /// <param name="_page"></param>
        /// <param name="type"></param>
        public void meta_og_type(Page _page, string type)
        {
            HtmlMeta tagtype = new HtmlMeta();
            tagtype.Attributes.Add("property", "og:type");
            tagtype.Content = type;
            _page.Header.Controls.Add(tagtype);
        }

        /// <summary>
        /// An image URL for the image to show in the user’s timeline.
        /// </summary>
        /// <param name="_page"></param>
        /// <param name="img"></param>
        public void meta_image(Page _page, string img)
        {
            HtmlMeta tagimg = new HtmlMeta();
            tagimg.Attributes.Add("property", "og:image");
            tagimg.Content = img;
            _page.Header.Controls.Add(tagimg);
        }

        /// <summary>
        /// The description Facebook will show for the content, maximum 300 characters.
        /// </summary>
        /// <param name="_page"></param>
        /// <param name="des"></param>
        public void meta_og_description(Page _page, string des)
        {
            HtmlMeta tagdescription = new HtmlMeta();
            tagdescription.Attributes.Add("property", "og:description");
            //tagdescription.Name = "description";
            tagdescription.Content = des;
            _page.Header.Controls.Add(tagdescription);
        }

        /// <summary>
        /// The URL of the page.
        /// </summary>
        /// <param name="_page"></param>
        /// <param name="des"></param>
        public void meta_og_url(Page _page, string url)
        {
            HtmlMeta tagdescription = new HtmlMeta();
            tagdescription.Attributes.Add("property", "og:url");
            tagdescription.Content = url;
            _page.Header.Controls.Add(tagdescription);
        }

        /// <summary>
        /// The locale of the page.
        /// </summary>
        /// <param name="_page"></param>
        /// <param name="des"></param>
        public void meta_og_appid(Page _page, string appid)
        {
            HtmlMeta tagdescription = new HtmlMeta();
            tagdescription.Attributes.Add("property", "og:app_id");
            tagdescription.Content = appid;
            _page.Header.Controls.Add(tagdescription);
        }

        /// <summary>
        /// The locale of the page.
        ///<meta property="og:locale" content="en_US" />
        ///<meta property="og:locale:alternate" content="fr_FR" />
        ///<meta property="og:locale:alternate" content="es_ES" />
        /// </summary>
        /// <param name="_page"></param>
        /// <param name="des"></param>
        public void meta_og_locale(Page _page, string locale)
        {
            var SP_LOCALE = locale.Contains(";")
                ? locale.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries)
                : new[] { locale };
            if (!SP_LOCALE.Any()) return;
            HtmlMeta httpequiv = new HtmlMeta();
            for (int i = 0; i < SP_LOCALE.Length; i++)
            {
                var iLocale = SP_LOCALE[i];
                if (i == 0)
                {
                    httpequiv.Attributes.Add("og:locale", iLocale);
                }
                else
                {
                    httpequiv.Attributes.Add("og:locale:alternate", iLocale);
                }
            }
            _page.Header.Controls.Add(httpequiv);
        }

        #endregion

        #region Twitter Cards META TAG

        /// <summary>
        /// the title of the content,maximum 70 characters.
        /// EX: summary, photo, gallery, app etc...
        /// </summary>
        /// <param name="_page"></param>
        /// <param name="title"></param>
        public void meta_Twitter_Cards(Page _page, string card = "summary")
        {
            HtmlMeta tagTitle = new HtmlMeta();
            tagTitle.Attributes.Add("name", "twitter:card");
            tagTitle.Content = card;
            _page.Header.Controls.Add(tagTitle);
        }

        /// <summary>
        /// the title of the content,maximum 70 characters.
        /// </summary>
        /// <param name="_page"></param>
        /// <param name="title"></param>
        public void meta_Twitter_Cards_title(Page _page, string title = "E-commerce")
        {
            HtmlMeta tagTitle = new HtmlMeta();
            tagTitle.Attributes.Add("name", "twitter:title");
            tagTitle.Content = title;
            _page.Header.Controls.Add(tagTitle);
        }

        /// <summary>
        ///  the card type, default is “summary”.
        /// </summary>
        /// <param name="_page"></param>
        /// <param name="type"></param>
        //public void meta_Twitter_Cards_type(Page _page, string type)
        //{
        //    HtmlMeta tagtype = new HtmlMeta();
        //    tagtype.Attributes.Add("property", "twitter:card");
        //    tagtype.Content = type;
        //    _page.Header.Controls.Add(tagtype);
        //}

        /// <summary>
        /// The Twitter @username the card should be attributed to. Required for Twitter Card analytics.
        /// </summary>
        /// <param name="_page"></param>
        /// <param name="des"></param>
        public void meta_Twitter_Cards_site(Page _page, string site)
        {
            HtmlMeta tagdescription = new HtmlMeta();
            tagdescription.Attributes.Add("name", "twitter:site");
            tagdescription.Content = site;
            _page.Header.Controls.Add(tagdescription);
        }

        /// <summary>
        ///the image that will be displayed on the Twitter Card
        /// </summary>
        /// <param name="_page"></param>
        /// <param name="img"></param>
        public void meta_Twitter_Cards_image(Page _page, string img)
        {
            HtmlMeta tagimg = new HtmlMeta();
            tagimg.Attributes.Add("name", "twitter:image");
            tagimg.Content = img;
            _page.Header.Controls.Add(tagimg);
        }

        /// <summary>
        /// the description of the content, maximum 200 characters
        /// </summary>
        /// <param name="_page"></param>
        /// <param name="des"></param>
        public void meta_Twitter_Cards_description(Page _page, string des)
        {
            HtmlMeta tagdescription = new HtmlMeta();
            tagdescription.Attributes.Add("name", "twitter:description");
            //tagdescription.Name = "description";
            tagdescription.Content = des;
            _page.Header.Controls.Add(tagdescription);
        }

        /// <summary>
        /// The URL of the content.
        /// </summary>
        /// <param name="_page"></param>
        /// <param name="des"></param>
        public void meta_Twitter_Cards_url(Page _page, string url)
        {
            HtmlMeta tagdescription = new HtmlMeta();
            tagdescription.Attributes.Add("name", "twitter:url");
            tagdescription.Content = url;
            _page.Header.Controls.Add(tagdescription);
        }

        #endregion

        public void meta_keyword(Page _page, string keyword)
        {
            HtmlMeta tagAuthor = new HtmlMeta
            {
                Name = "keyword",
                Content = keyword
            };
            _page.Controls.Add(tagAuthor);
        }

        public void meta_page_icon(Page _page, string icon)
        {
            using (HtmlGenericControl _icon = new HtmlGenericControl("link"))
            {
                _icon.Attributes.Add("rel", "icon"); //16x16
                _icon.Attributes.Add("href", icon.ToLower());
                _page.Header.Controls.Add(_icon);
            }
            using (HtmlGenericControl icon144 = new HtmlGenericControl("link"))
            {
                icon144.Attributes.Add("rel", "apple-touch-icon-precomposed");
                icon144.Attributes.Add("sizes", "144x144");
                icon144.Attributes.Add("href", icon.ToLower());
                _page.Header.Controls.Add(icon144);
            }
            using (HtmlGenericControl icon180 = new HtmlGenericControl("link"))
            {
                icon180.Attributes.Add("rel", "apple-touch-icon-precomposed");
                icon180.Attributes.Add("sizes", "180x180");
                icon180.Attributes.Add("href", icon.ToLower());
                _page.Header.Controls.Add(icon180);
            }
        }

        public void canonical(Page _page, string link)
        {
            HtmlGenericControl canonical = new HtmlGenericControl("link");
            canonical.Attributes.Add("rel", "canonical");
            canonical.Attributes.Add("href", link.ToLower());
            _page.Header.Controls.Add(canonical);
        }

        public void meta_httpequiv(Page _page, string charset = "utf-8")
        {
            HtmlMeta httpequiv = new HtmlMeta();
            httpequiv.Attributes.Add("http-equiv", "refresh");
            httpequiv.Attributes.Add("content", "230");
            _page.Header.Controls.Add(httpequiv);
        }

        public void meta_robot(Page _page, string robot)
        {
            HtmlMeta meta = new HtmlMeta
            {
                Name = "robots",
                Content = "NOODP,index,follow"
            };
            _page.Header.Controls.Add(meta);
        }

        public void meta_sitename(Page _page, string sitename)
        {
            HtmlMeta tagsite_name = new HtmlMeta();
            tagsite_name.Attributes.Add("property", "og:site_name");
            tagsite_name.Content = sitename;
            _page.Header.Controls.Add(tagsite_name);
        }

        public void meta_author(Page _page, string author)
        {
            HtmlMeta tagAuthor = new HtmlMeta
            {
                Name = "author",
                Content = author
            };
            _page.Controls.Add(tagAuthor);
        }

        #endregion


        public string WEB_PAGE_PHOTO_NO_IMAGES(int STYLE_PHOTO = 1)
        {
            var HTML = "";
            string _domain = ConfigurationManager.AppSettings["domain"];
            try
            {
                var PHOTO_URL = STYLE_PHOTO == 1 ? "images/270x270.jpg" : "images/480x250.jpg";
                HTML = _domain + PHOTO_URL;
            }
            catch (Exception ex)
            {
            }
            return HTML;
        }
    }
}
