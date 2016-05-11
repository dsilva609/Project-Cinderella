(function() {
  Namespace("Views.Album");

  Views.Album.Index = function() {};

  Views.Album.Index = (function() {
    function Index() {}

    Index.prototype.init = function() {
      return false;
    };

    return Index;

  })();

  $(function() {
    var index;
    index = new Views.Album.Index;
    return index.init();
  });

}).call(this);
