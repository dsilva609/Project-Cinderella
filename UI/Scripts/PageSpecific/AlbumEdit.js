(function() {
  Namespace("Views.Album");

  Views.Album.Edit = function() {};

  Views.Album.Edit = (function() {
    function Edit() {}

    Edit.prototype.init = function() {};

    return Edit;

  })();

  $(function() {
    var edit;
    edit = new Views.Album.Edit;
    return edit.init();
  });

}).call(this);
