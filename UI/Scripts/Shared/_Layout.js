Namespace("Views.Shared");

Views.Shared.Layout = function() {};

Views.Shared.Layout = (function() {
  function Layout() {}

  Layout.prototype.init = function() {
    return $(".datepicker").datepicker({
      autoclose: true,
      todayBtn: true,
      todayHighlight: true,
      toggleActive: true,
      dateFormat: "mm/dd/yyyy",
      changeMonth: true,
      changeYear: true,
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
