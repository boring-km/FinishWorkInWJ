function sayHello(){
    const width = 440;
    const height = 460;

    const left = (window.screen.width / 2) - (width / 2);
    const top = (window.screen.height / 4);

    const windowStatus = 'width='+width+', height='+height+', left='+left+', top='+top+', scrollbars=no, status=no, resizable=no, titlebar=no';
    new Promise(resolve => setTimeout(resolve, 100))
        .then(() => window.open("https://portal.wjtb.net/portal/popup/P0009/p0009.do?popupFormId=p0009f24&condition=Y^1&targetType=N", "174", windowStatus));
}

window.onload = sayHello;