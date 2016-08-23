Namespace("Views.Shared");

Views.Shared.Layout = function() {};

Views.Shared.Layout = (function() {
  var deleteItem;

  function Layout() {}

  deleteItem = function(item) {
    var ID;
    ID = $(item).data("id");
    bootbox.dialog({
      message: "Are you sure you want to delete this item?",
      buttons: {
        cancel: {
          label: "No"
        },
        confirm: {
          label: "Yes",
          className: "btn-danger",
          callback: function() {
            return window.location.href = deleteUrl + "/" + ID;
          }
        }
      }
    });
    return false;
  };

  Layout.prototype.init = function() {
    $(".datepicker").datepicker({
      autoclose: true,
      todayBtn: true,
      todayHighlight: true,
      toggleActive: true,
      dateFormat: "mm/dd/yyyy",
      changeMonth: true,
      changeYear: true,
      showButtonPanel: true
    });
    $('[class~=deleteBtn]').on("click", function() {
      deleteItem($(this));
      return false;
    });
    $('#deleteBtn').on("click", function() {
      deleteItem($(this));
      return false;
    });
    return $('.panel-collapse').on("click", function() {
      return $(this).find("span").toggleClass("fa-chevron-circle-down fa-chevron-circle-up");
    });
  };

  return Layout;

})();

$(function() {
  var _layout;
  _layout = new Views.Shared.Layout;
  return _layout.init();
});
