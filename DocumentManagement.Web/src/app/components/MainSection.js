class MainSection {
  /** @ngInject */
  constructor(documentService) {
    this.documentService = documentService;
    this.documents = [];
  }

  handleUpload() {
    this.documents = this.documentService.upload();
  }

  handleDownload() {
    this.documents = this.documentService.download(id);
  }

  handleDelete() {
    this.documents = this.documentService.download(id);
  }
}

angular
  .module('app')
  .component('mainSection', {
    templateUrl: 'app/components/MainSection.html',
    controller: MainSection,
    bindings: {
    }
  });
