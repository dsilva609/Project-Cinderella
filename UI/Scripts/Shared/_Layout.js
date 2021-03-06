﻿// Generated by IcedCoffeeScript 108.0.11
(function() {
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
      $('.panel-collapse').on("click", function() {
        return $(this).find("span").toggleClass("fa-chevron-circle-down fa-chevron-circle-up");
      });
      $('.flip').on("click", function() {
        $(this).find(".card").toggleClass("flipped flip");
        return false;
      });
      $('[data-toggle="tooltip"]').tooltip();
      $('.carousel').carousel({
        interval: 5000
      });
      $('.carousel').bcSwipe({
        threshold: 50
      });
      return $(".category").select2({
        placeholder: "Select a category",
        tags: true,
        tokenSeparators: [',']
      });
    };

    return Layout;

  })();

  $(function() {
    var _layout;
    _layout = new Views.Shared.Layout;
    return _layout.init();
  });

}).call(this);
