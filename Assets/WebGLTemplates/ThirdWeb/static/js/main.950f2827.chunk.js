(this["webpackJsonpunity-webgl-template"]=this["webpackJsonpunity-webgl-template"]||[]).push([[0],{10:function(e,n,t){},12:function(e,n,t){"use strict";t.r(n);var i=t(0),r=t.n(i),o=t(4),c=t.n(o),u=(t(10),t(2)),s=t(14),a=t(5),l=function(){function e(){Object(u.a)(this,e),this.signer=null}return Object(a.a)(e,[{key:"setSigner",value:function(e){this.signer=e}},{key:"loggedIn",value:function(e){return Promise.resolve(!1)}},{key:"invokeRoute",value:function(e,n){if("thirdweb.logged_in"===e)return this.loggedIn(n);throw new Error("uknown route")}}]),e}(),d=null,h=function e(){var n=this;Object(u.a)(this,e),this.thirdWeb=void 0,this.thirdWeb=new l;var t=window;t.unity={},t.unity.invoke=function(e,i){console.log("invoke called",e,i);var r=Object(s.a)();return n.thirdWeb.invokeRoute(e,JSON.parse(i)).then((function(e){console.log("invoke route result",e);var n=JSON.stringify({ack_id:r,result:e});t.unityInstance.SendMessage("ThirdWeb","Callback",n)})),r}};var v=t(1);var f=function(){var e=Object(i.useRef)(null);return d||(d=new h),Object(i.useEffect)((function(){if(e.current)var n=setInterval((function(){window.createUnityInstance&&(clearInterval(n),window.createUnityInstance(e.current,window.unityConfig).then((function(e){window.unityInstance=e})))}),500)}),[e]),Object(v.jsxs)("div",{children:["hello",Object(v.jsx)("canvas",{ref:e,id:"unity-canvas",width:"960",height:"600",style:{width:"960px",height:"600px",cursor:"default"}})]})};c.a.render(Object(v.jsx)(r.a.StrictMode,{children:Object(v.jsx)(f,{})}),document.getElementById("root"))}},[[12,1,2]]]);
//# sourceMappingURL=main.950f2827.chunk.js.map