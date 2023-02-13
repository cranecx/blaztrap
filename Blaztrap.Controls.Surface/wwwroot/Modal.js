function getModalInstance(element) {
    return bootstrap.Modal.getOrCreateInstance(element);
}

export function showModal(element) {
    let modal = getModalInstance(element);
    modal.show();
}

export function hideModal(element) {
    let modal = getModalInstance(element);
    modal.hide();
}