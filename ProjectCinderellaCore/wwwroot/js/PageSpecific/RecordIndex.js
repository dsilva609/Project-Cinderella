(function() {
  Namespace("Views.Record");

  Views.Record.Index = function() {};

  Views.Record.Index = (function() {
    function Index() {}

    Index.prototype.init = function() {
      return $('[id=deleteRecord]').on("click", function() {
        var ID;
        ID = $(this).data("id");
        bootbox.dialog({
          message: "Are you sure you want to delete this record?",
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

    return Index;

  })();

  $(function() {
    var index;
    index = new Views.Record.Index;
    return index.init();
  });

}).call(this);
