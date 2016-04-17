Namespace("Views.Shared");

Views.Shared.Layout = function() {};

Views.Shared.Layout = (function() {
  function Layout() {}

  Layout.prototype.init = function() {
    $(".datepicker").datepicker();
    return $(".datepicker-year").datepicker({
      dateFormat: "yy",
      changeYear: true,
      changeMonth: false,
      showButtonPanel: true
    });
  };

  return Layout;

})();

$(function() {
  var _layout;
  _layout = new Views.Shared.Layout;
  return _layout.init();
});
