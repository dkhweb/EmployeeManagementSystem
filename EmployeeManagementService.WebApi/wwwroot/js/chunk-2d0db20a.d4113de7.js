(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["chunk-2d0db20a"],{"6f15":function(e,t,r){"use strict";r.r(t);var n=function(){var e=this,t=e.$createElement,r=e._self._c||t;return r("div",{staticClass:"container"},[r("div",{directives:[{name:"show",rawName:"v-show",value:e.error,expression:"error"}],staticClass:"alert alert-danger"},[e._v(e._s(e.error))]),r("b-form",{on:{submit:e.createDepartment}},[r("b-form-group",{attrs:{id:"input-group-1",label:"Name:","label-for":"input-1"}},[r("b-form-input",{attrs:{id:"input-1",type:"text",placeholder:"Enter Department Name",maxlength:"200",required:""},model:{value:e.department.name,callback:function(t){e.$set(e.department,"name",t)},expression:"department.name"}})],1),r("b-button",{attrs:{type:"submit",variant:"primary"}},[e._v("Submit")])],1)],1)},a=[],o=r("1da1"),s=(r("96cf"),r("bc3a")),i=r.n(s),u={data:function(){return{error:"",department:{}}},methods:{createDepartment:function(e){var t=this;return Object(o["a"])(regeneratorRuntime.mark((function r(){return regeneratorRuntime.wrap((function(r){while(1)switch(r.prev=r.next){case 0:return e.preventDefault(),r.next=3,i()({url:"/api/departments",method:"post",headers:{"content-type":"application/json"},data:JSON.stringify(t.department)}).then((function(){return t.$router.push({path:"/"})})).catch((function(e){e.response.data.error&&(t.error=e.response.data.error)}));case 3:case"end":return r.stop()}}),r)})))()}}},p=u,c=r("2877"),m=Object(c["a"])(p,n,a,!1,null,null,null);t["default"]=m.exports}}]);
//# sourceMappingURL=chunk-2d0db20a.d4113de7.js.map