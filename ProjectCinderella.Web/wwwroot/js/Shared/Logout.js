(function() {
  Namespace("Views.Shared");

  Views.Shared.Logout = function() {
    return this._LogOffBtn = null;
  };

  Views.Shared.Logout = (function() {
    function Logout() {}

    Logout.prototype.init = function() {
      var parent;
      parent = this;
      this._LogOffBtn = $("#logOffBtn");
      return this._LogOffBtn.on("click", function(event) {
        bootbox.dialog({
          message: "Are you sure you want to log out?",
          buttons: {
            cancel: {
              label: "No",
              callback: function() {
                return event.preventDefault();
              }
            },
            confirm: {
              label: "Yes",
              callback: function() {
                return $("#logoutForm").submit();
              }
            }
          }
        });
        return event.preventDefault();
      });
    };

    return Logout;

  })();

  $(function() {
    var logout;
    logout = new Views.Shared.Logout;
    return logout.init();
  });

}).call(this);

//# sourceMappingURL=Logout.js.map
