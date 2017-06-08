(function() {
  Namespace("Views.Album");

  Views.Album.Layout = function() {};

  Views.Album.Edit = (function() {
    function Edit() {}

    Edit.prototype.init = function() {
      return $("#ddlAlbumType").on("change", function() {
        if ($("#ddlAlbumType :selected").text() === "Vinyl") {
          return $("#vinylInfo").removeClass("hidden");
        } else {
          return $("#vinylInfo").addClass("hidden");
        }
      });
    };

    return Edit;

  })();

  $(function() {
    var _edit;
    _edit = new Views.Album.Edit;
    return _edit.init();
  });

}).call(this);
