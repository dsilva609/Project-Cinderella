(function() {
  Namespace("Views.Album");

  Views.Album.Index = function() {};

  Views.Album.Index = (function() {
    function Index() {}

    Index.prototype.init = function() {
      return $('[id=deleteAlbum]').on("click", function() {
        var ID;
        ID = $(this).data("id");
        bootbox.dialog({
          message: "Are you sure you want to delete this album?",
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
    index = new Views.Album.Index;
    return index.init();
  });

}).call(this);
