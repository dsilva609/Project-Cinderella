(function() {
  Namespace("Views.Album");

  Views.Album.Details = function() {};

  Views.Album.Details = (function() {
    function Details() {}

    Details.prototype.init = function() {};

    return Details;

  })();

  $(function() {
    var details;
    details = new Views.Album.Details;
    return details.init();
  });

}).call(this);
