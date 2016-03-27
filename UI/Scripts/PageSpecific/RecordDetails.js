(function() {
  Namespace("Views.Record");

  Views.Record.Details = function() {};

  Views.Record.Details = (function() {
    function Details() {}

    Details.prototype.init = function() {
      return $('[id=recordDeleteBtn]').on("click", function() {
        var ID;
        ID = $(this).data("id");
        bootbox.dialog({
          message: "Are you sure you want to remove this record?",
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
      });
    };

    return Details;

  })();

  $(function() {
    var details;
    details = new Views.Record.Details;
    return details.init();
  });

}).call(this);
