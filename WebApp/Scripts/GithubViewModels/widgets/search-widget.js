ko.components.register('search-widget', {
    viewModel: function (params) {
        var self = this;
        self.githubUser = params.githubUser;
        self.error = ko.observable();

        // Behaviors
        self.searchUser = function(formElement) {
            var searchInput = formElement.elements.userName;
            if (searchInput) {
                var searchInputValue = searchInput.value;
                var url = '/api/search/users/' + searchInputValue;
                $.get(url, function (result) {
                    self.githubUser({
                        login: searchInputValue,
                        name: result.Name,
                        followerscount: result.Followers,
                        publicrepos: result.Public_Repos,
                        show: true,
                        repos: [],
                        stargazers: []
                    });
                    self.error(null);
                }).fail(function (resp) {
                    self.githubUser({
                        show: false,
                        repos: [],
                        stargazers: []
                    });

                    if(resp && resp.responseJSON && resp.responseJSON.Message)
                        self.error(resp.responseJSON.Message);
                });
            }
        }.bind(self);
    },
    template:
        '<div style="margin: 10px">\
            <form class="row" data-bind="submit: searchUser">\
                <div class="col-lg-9">\
                    <input type="text" class="form-control" Id="userName" placeholder="Github user name">\
                </div>\
                <button type="submit" class="btn btn-default col-lg-3">Search</button>\
            </form>\
            <div class="alert alert-danger" style="margin-top: 5px; padding: 10px;" data-bind="visible: error">\
                <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>\
                <span data-bind="text: error"></span>\
            </div>\
        </div>'
});