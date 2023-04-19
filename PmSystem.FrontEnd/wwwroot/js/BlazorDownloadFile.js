window.BlazorDownloadFile = {
    downloadFile: function (fileName, href) {
        const anchor = document.createElement("a");
        anchor.setAttribute("href", href);
        anchor.setAttribute("download", fileName);
        anchor.click();
        anchor.remove();
    }
};