ko.components.register('repos-widget', {
    viewModel: function (params) {
        var self = this;
        self.githubUser = params.githubUser;

        // Behaviors
        self.getStargazers = function (repo) {
            var url = '/api/search/users/' + self.githubUser().login + '/repos/' + repo.Name + '/stargazers';
            $.get(url, function(stargazers) {
                var user = self.githubUser();

                user.stargazers = stargazers;

                self.githubUser(user);
            }).fail(function() {
                var user = self.githubUser();

                user.stargazers = [];

                self.githubUser(user);
            });
        }.bind(self);
    },
    template:
        '<div class="panel panel-primary" data-bind="visible: githubUser().repos && githubUser().repos.length">\
            <div class="panel-heading">Public repos</div>\
            <table class="table">\
                <thead>\
                <tr>\
                    <th>Name</th>\
                    <th>Stargazzers count</th>\
                    <th>Show stargazzers</th>\
                </tr>\
                </thead>\
                <tbody class="repos-table-body" data-bind="foreach: githubUser().repos">\
                <tr>\
                    <td data-bind="text: Name"></td>\
                    <td data-bind="text: Stargazers_Count"></td>\
                    <td data-bind="visible: Stargazers_Count > 0">\
                        <div class="btn btn-default" data-bind="click: $parent.getStargazers">Show stargazzers</div></td>\
                </tr>\
                </tbody>\
            </table>\
        </div>'
});