function getOffcanvasInstance(element) {
    return bootstrap.Offcanvas.getOrCreateInstance(element);
}

export function showOffcanvas(element) {
    let offcanvas = getOffcanvasInstance(element);
    offcanvas.show();
}

export function hideOffcanvas(element) {
    let offcanvas = getOffcanvasInstance(element);
    offcanvas.hide();
}