ko.components.register('search-widget', {
    viewModel: function (params) {
        var self = this;
        self.githubUserLogin = params.githubUserLogin;
        self.githubUser = params.githubUser;

        // Behaviors
        self.searchUser = function(formElement) {
            var searchInput = formElement.elements.userName;
            if (searchInput) {
                var searchInputValue = searchInput.value;
                self.githubUserLogin(searchInputValue);
                var url = '/api/search/users/' + searchInputValue;
                $.get(url, function (result) {
                    self.githubUser({
                        name: result.Name,
                        followerscount: result.Followers,
                        publicrepos: result.Public_Repos,
                        show: true
                    });
                }).fail(function() {
                    self.githubUser({
                        name: result.Name,
                        followerscount: result.Followers,
                        publicrepos: result.Public_Repos,
                        show: false
                    });
                });
            }
        }.bind(self);
    },
    template:
        '<form class="row" data-bind="submit: searchUser">\
            <div class="col-lg-9">\
                <input type="text" class="form-control" Id="userName" placeholder="Github user name">\
            </div>\
            <button type="submit" class="btn btn-default col-md-3 search-button">Search</button>\
        </form>'
});