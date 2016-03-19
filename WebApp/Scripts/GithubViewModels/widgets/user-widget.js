ko.components.register('user-widget', {
    viewModel: function (params) {
        var self = this;
        self.githubUser = params.githubUser;

        // Behaviors
        self.getRepos = function () {
            var url = '/api/search/users/' + self.githubUser().login + '/repos';
            $.get(url, function (repos) {
                var user = self.githubUser();

                user.repos = repos;
                user.stargazers = [];

                self.githubUser(user);
            }).fail(function () {
                var user = self.githubUser();

                user.repos = [];
                user.stargazers = [];

                self.githubUser(user);
            });
        }.bind(self);
    },
    template:
        '<div class="panel panel-primary" data-bind="visible: githubUser().show">\
            <div class="panel-heading">Github user</div>\
            <div class="panel-body list-group">\
                <div class="list-group-item user-name">Name: <span data-bind="text: githubUser().name"/></div>\
                <div class="list-group-item user-followers">Followers count: <span data-bind="text: githubUser().followerscount"/></div>\
                <div class="list-group-item user-repos">\
                    <div class="btn btn-default" data-bind="click: getRepos">Public repos: <span data-bind="text: githubUser().publicrepos"/></div>\
                </div>\
            </div>\
        </div>'
});