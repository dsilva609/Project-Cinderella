(function() {
  Namespace("Views.Album");

  Views.Album.Details = function() {};

  Views.Album.Details = (function() {
    function Details() {}

    Details.prototype.init = function() {
      return $('[id=albumDeleteBtn]').on("click", function() {
        var ID;
        ID = $(this).data("id");
        bootbox.dialog({
          message: "Are you sure you want to remove this album?",
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
    details = new Views.Album.Details;
    return details.init();
  });

}).call(this);
