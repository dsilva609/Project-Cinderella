(function() {
  Namespace("Views.Album");

  Views.Album.Edit = function() {};

  Views.Album.Edit = (function() {
    function Edit() {}

    Edit.prototype.init = function() {
      return $("#btnDelete").on("click", function() {
        var ID, deleteUrl;
        ID = $(this).data("id");
        deleteUrl = $(this).data("deleteurl");
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

    return Edit;

  })();

  $(function() {
    var edit;
    edit = new Views.Album.Edit;
    return edit.init();
  });

}).call(this);
