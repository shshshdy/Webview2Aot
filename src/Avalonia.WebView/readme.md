### MAC Webview

-   1、创建 WKWebViewBridge.m

```object-c
#import <WebKit/WebKit.h>
#import <Cocoa/Cocoa.h>

// 全局保存WKWebView实例（简化内存管理）
static WKWebView* g_webView = nil;

// 1. 创建WKWebView（C接口）
void* CreateWKWebView(void* parentView, int x, int y, int width, int height) {
    NSView* nsParentView = (__bridge NSView*)parentView;
    CGRect frame = CGRectMake(x, y, width, height);

    // 配置WKWebView
    WKWebViewConfiguration* config = [[WKWebViewConfiguration alloc] init];
    g_webView = [[WKWebView alloc] initWithFrame:frame configuration:config];
    [nsParentView addSubview:g_webView];

    return (__bridge void*)g_webView;
}

// 2. 加载URL（C接口）
void WKWebViewLoadURL(const char* urlStr) {
    if (!g_webView) return;
    NSString* nsUrl = [NSString stringWithUTF8String:urlStr];
    NSURL* url = [NSURL URLWithString:nsUrl];
    [g_webView loadRequest:[NSURLRequest requestWithURL:url]];
}

// 3. 销毁WKWebView（C接口）
void DestroyWKWebView() {
    [g_webView removeFromSuperview];
    g_webView = nil;
}
```

-   2、生成动态库 WKWebViewBridge.m

```sh
# 编译命令：-framework 引入WebKit/Cocoa依赖，-dynamiclib 生成动态库
clang -framework WebKit -framework Cocoa -dynamiclib WKWebViewBridge.m -o libWKWebViewBridge.dylib
```
