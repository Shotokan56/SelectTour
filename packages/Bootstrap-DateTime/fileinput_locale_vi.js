/*!
 * FileInput Vietnamese Translations
 *
 * This file must be loaded after 'fileinput.js'. Patterns in braces '{}', or
 * any HTML markup tags in the messages must not be converted or translated.
 *
 * @see http://github.com/kartik-v/bootstrap-fileinput
 *
 * NOTE: this file must be saved in UTF-8 encoding.
 */
(function ($) {
    "use strict";

    $.fn.fileinputLocales['vi'] = {
        fileSingle: 'file',
        filePlural: 'files',
        browseLabel: 'Chọn &hellip;',
        removeLabel: 'Xóa',
        removeTitle: 'Xóa các file đã chọn',
        cancelLabel: 'Hủy',
        cancelTitle: 'Bỏ qua tiếp tục upload',
        uploadLabel: 'Upload',
        uploadTitle: 'Upload các file đã chọn',
        msgSizeTooLarge: 'File "{name}" (<b>{size} KB</b>) vượt quá dung lượng tối đa <b>{maxSize} KB</b>. Vui lòng thử lại!',
        msgFilesTooLess: 'Bạn phải chọn ít nhất <b>{n}</b> {files} để upload. Vui lòng thử lại!',
        msgFilesTooMany: 'Số file upload <b>({n})</b> vượt quá <b>{m}</b>. Vui lòng thử lại!',
        msgFileNotFound: 'File "{name}" không tìm thấy!',
        msgFileSecured: 'Hạn chế bảo mật ngăn chặn đọc file này "{name}".',
        msgFileNotReadable: 'File "{name}" không thể đọc được.',
        msgFilePreviewAborted: 'Không xem trước được nội dung file "{name}".',
        msgFilePreviewError: 'Lỗi xuất hiện khi đọc file "{name}".',
        msgInvalidFileType: 'File không đúng định dạng "{name}". Chỉ có các files "{types}" được hỗ trợ.',
        msgInvalidFileExtension: 'Phần mở rộng file "{name}" không hợp lệ. Chỉ hỗ trợ các files "{extensions}".',
        msgValidationError: 'Có lỗi khi Upload file',
        msgLoading: 'Đang xử lý file {index} of {files} &hellip;',
        msgProgress: 'Xử lý file {index} of {files} - {name} - {percent}% hoàn thành.',
        msgSelected: '{n} {files} được chọn',
        msgFoldersNotAllowed: 'Chỉ kéo & thả files! Bỏ qua {n} thư mục được kéo thả.',
        dropZoneTitle: 'Kéo & thả files vào đây &hellip;'
    };
})(window.jQuery);