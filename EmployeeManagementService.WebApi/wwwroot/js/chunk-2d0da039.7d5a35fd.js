(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["chunk-2d0da039"],{"6a91":function(t,e,r){"use strict";r.r(e);var n=function(){var t=this,e=t.$createElement,r=t._self._c||e;return r("div",{staticClass:"container"},[r("b-form",{on:{submit:t.editDepartment}},[r("b-form-group",{attrs:{id:"input-group-1",label:"Name:","label-for":"input-1"}},[r("b-form-input",{attrs:{id:"input-1",type:"text",placeholder:"Enter Department Name",maxlength:"200",required:""},model:{value:t.department.name,callback:function(e){t.$set(t.department,"name",e)},expression:"department.name"}})],1),r("b-button",{attrs:{type:"submit",variant:"primary"}},[t._v("Submit")])],1)],1)},a=[],i=r("1da1"),u=r("5530"),o=(r("96cf"),r("2f62")),p=r("bc3a"),c=r.n(p),s={data:function(){return{error:""}},created:function(){this.getDepartment(this.$route.params.id)},computed:Object(u["a"])({},Object(o["c"])(["department"])),methods:Object(u["a"])(Object(u["a"])({},Object(o["b"])(["getDepartment"])),{},{editDepartment:function(t){var e=this;return Object(i["a"])(regeneratorRuntime.mark((function r(){return regeneratorRuntime.wrap((function(r){while(1)switch(r.prev=r.next){case 0:return t.preventDefault(),r.next=3,c()({url:"/api/departments",method:"put",headers:{"content-type":"application/json"},data:JSON.stringify(e.department)}).then((function(){return e.$router.push({path:"/"})})).catch((function(t){t.response.data.error&&(e.error=t.response.data.error)}));case 3:case"end":return r.stop()}}),r)})))()}})},m=s,d=r("2877"),l=Object(d["a"])(m,n,a,!1,null,null,null);e["default"]=l.exports}}]);
//# sourceMappingURL=chunk-2d0da039.7d5a35fd.js.map