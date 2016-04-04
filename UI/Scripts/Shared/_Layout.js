Namespace("Views.Shared");

Views.Shared.Layout = function() {};

Views.Shared.Layout = (function() {
  function Layout() {}

  Layout.prototype.init = function() {
    return $(".datepicker").datepicker({
      dateformat: "MM/dd/yy"
    });
  };

  return Layout;

})();

$(function() {
  var _layout;
  _layout = new Views.Shared.Layout;
  return _layout.init();
});
