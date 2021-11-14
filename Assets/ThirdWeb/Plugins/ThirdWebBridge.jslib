mergeInto(LibraryManager.library, {

  ThirdWebInvoke: function (route, payload) {
    var returnStr = window.unity.invoke(Pointer_stringify(route), Pointer_stringify(payload));
    var bufferSize = lengthBytesUTF8(returnStr) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(returnStr, buffer, bufferSize);
    return buffer;
  }

});