﻿
angular
    .module("umbraco")
    .controller("nuPickers.Shared.RadioButtonPicker.RadioButtonPickerEditorController",
        ['$scope', 'nuPickers.Shared.Editor.EditorResource',
        function ($scope, editorResource) {

            editorResource.getEditorDataItems($scope.model.config).then(function (response) {
                $scope.radioButtonPickerOptions = response.data;                               

                editorResource.getPickedKeys($scope.model).then(function (pickedKeys) {
                    $scope.pickedKey = pickedKeys[0];
                });

                $scope.$on("formSubmitting", function () {

                    var i = 0;
                    var found = false;
                    var pickedOption = null;
                    do {
                        if ($scope.radioButtonPickerOptions[i].key == $scope.pickedKey) {

                            pickedOption = $scope.radioButtonPickerOptions[i];
                            found = true;
                        }
                        i++;

                    } while (!found && i < $scope.radioButtonPickerOptions.length)


                    $scope.model.value = editorResource.createSaveValue($scope.model.config, [pickedOption]);

                    editorResource.updateRelationMapping($scope.model, [pickedOption]);

                });

            });

        }]);