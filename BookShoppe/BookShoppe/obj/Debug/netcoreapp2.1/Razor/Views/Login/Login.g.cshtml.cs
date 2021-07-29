#pragma checksum "D:\DA_BookMarket\BookShoppe\BookShoppe\Views\Login\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8a2469b4dfcd8945e3cfc2bdd2891098f239b6a5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_Login), @"mvc.1.0.view", @"/Views/Login/Login.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Login/Login.cshtml", typeof(AspNetCore.Views_Login_Login))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\DA_BookMarket\BookShoppe\BookShoppe\Views\_ViewImports.cshtml"
using BookShoppe;

#line default
#line hidden
#line 2 "D:\DA_BookMarket\BookShoppe\BookShoppe\Views\_ViewImports.cshtml"
using BookShoppe.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a2469b4dfcd8945e3cfc2bdd2891098f239b6a5", @"/Views/Login/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92e8016d76662b5f25413dc176d7fd5d83ebe68a", @"/Views/_ViewImports.cshtml")]
    public class Views_Login_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("login-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\DA_BookMarket\BookShoppe\BookShoppe\Views\Login\Login.cshtml"
  
    ViewData["Title"] = "Login";
    Layout = "~/Views/Layouts/_Layout.cshtml";

#line default
#line hidden
            BeginContext(91, 1347, true);
            WriteLiteral(@"
<div class=""wrapper-breadcrums"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-sm-24"">
                <div class=""breadcrumbs"">
                    <ul>
                        <li class=""home"">
                            <a href=""index.html"" title=""Go to Home Page""><span>Trang chủ</span></a> <span class=""separator"">/ </span>
                        </li>
                        <li class=""cms_page"">
                            <strong>Đăng nhập</strong>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</div><!-- /.wrapper-breadcrums -->

<div class=""em-wrapper-main"">
    <div class=""container container-main"">
        <div class=""em-inner-main"">
            <div class=""em-wrapper-area02""></div>
            <div class=""em-main-container em-col1-layout"">
                <div class=""row"">
                    <div class=""em-col-main col-sm-24"">
                        <div c");
            WriteLiteral(@"lass=""account-login"">
                            <div class=""page-title em-box-02"">
                                <div class=""title-box"">
                                    <h1>Đăng nhập hoặc tạo tài khoản</h1>
                                </div>
                            </div>
                            ");
            EndContext();
            BeginContext(1438, 4683, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ac33e3dbd4e3439285771a00a4f90c2a", async() => {
                BeginContext(1474, 4640, true);
                WriteLiteral(@"
                                <input name=""form_key"" type=""hidden"" value=""W2ZAZqxDCT2TpZYs"" />
                                <div class=""col2-set"">
                                    <div class=""col-1 new-users"">
                                        <div class=""content"">
                                          
                                            <p>Bạn cần có tài khoản để tiếp tục, nếu chưa có hãy đăng kí tại đây</p>
                                        </div>
                                        <div class=""buttons-set"">
                                            <button type=""button"" title=""Create an Account"" class=""button"">
                                                <span><span>Đăng Kí Tài Khoản</span></span>
                                            </button>
                                        </div>
                                    </div>
                                    <div class=""col-2 registered-users"">
                                      ");
                WriteLiteral(@"  <div class=""content"">
                                            <h2>Đăng Nhập</h2>
                                            <p>Nếu đã có tài khoản đăng nhập tại đây</p>
                                            <ul class=""form-list"">
                                                <li>
                                                    <label for=""email"" class=""required""><em>*</em>Email</label>
                                                    <div class=""input-box"">
                                                        <input type=""text"" name=""login[username]"" value="""" id=""email"" class=""input-text required-entry validate-email"" title=""Email Address"" />
                                                    </div>
                                                </li>
                                                <li>
                                                    <label for=""pass"" class=""required""><em>*</em>Mật Khẩu</label>
                                                    <div");
                WriteLiteral(@" class=""input-box"">
                                                        <input type=""password"" name=""login[password]"" class=""input-text required-entry validate-password"" id=""pass"" title=""Password"" />
                                                    </div>
                                                </li>
                                                <li class=""control"">
                                                    <div class=""input-box"">
                                                        <input type=""checkbox"" name=""is_subscribed"" title=""Sign Up for Newsletter"" value=""1"" id=""is_subscribed"" class=""checkbox"" />
                                                    </div>
                                                    <label for=""is_subscribed"">Remember me</label>
                                                </li>
                                            </ul>
                                            <div id=""window-overlay"" class=""window-overlay"" style=""display:no");
                WriteLiteral(@"ne;""></div>
                                            
                                        </div>
                                        <div class=""buttons-set"">
                                            <button type=""submit"" class=""button"" title=""Login"" name=""send"" id=""send2"">
                                                <span><span>Đăng Nhập</span></span>
                                            </button>


                                            <a href=""#"" class=""f-left"">Quên Mật Khẩu</a>
                                            <p class=""required"">* Bắt buộc</p>
                                            <p>Hoặc đăng nhập bằng</p>
                                            <p class=""em-social"">
                                                <a class=""em-social-icon em-facebook f-left"" title=""em-sample-title"" href=""#""><span style=""color:#0078E8"" class=""fa fa-fw""></span><span style=""color:#0078E8"">Facebook</span></a>
                                            </p>");
                WriteLiteral(@"

                                          

                                            <p class=""em-social"">
                                                <a class=""em-social-icon em-google f-left"" title=""em-sample-title"" href=""#""><span style=""color:red"" class=""fa fa-fw""></span><span style=""color:red"">Google</span></a>
                                            </p>

                                        </div>
                                    </div>
                                </div>
                            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(6121, 192, true);
            WriteLiteral("\r\n                        </div><!-- /.account-login -->\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div><!-- /.em-wrapper-main -->\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
