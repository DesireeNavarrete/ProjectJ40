mergeInto(LibraryManager.library, {
  TryExitFullscreen: function () {
    var messages = [];
    var exited = false;

    function tryExit(doc, label) {
      try {
        var hasFullscreen =
          !!doc.fullscreenElement ||
          !!doc.webkitFullscreenElement;

        messages.push(label + ": " + hasFullscreen);

        if (doc.fullscreenElement && doc.exitFullscreen) {
          doc.exitFullscreen();
          exited = true;
        } else if (doc.webkitFullscreenElement && doc.webkitExitFullscreen) {
          doc.webkitExitFullscreen();
          exited = true;
        }
      } catch (e) {
        messages.push(label + ": blocked");
      }
    }

    function tryExitWindow(win, label) {
      try {
        tryExit(win.document, label);
      } catch (e) {
        messages.push(label + ": blocked");
      }
    }

    tryExit(document, "document");
    tryExitWindow(parent, "parent");
    tryExitWindow(top, "top");

    alert(
      "Fullscreen diagnostic:\n" +
      messages.join("\n") +
      "\nIntento salir: " + exited
    );
  }
});
