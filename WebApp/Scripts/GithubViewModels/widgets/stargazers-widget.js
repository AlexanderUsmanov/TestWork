ko.components.register('stargazers-widget', {
    viewModel: function (params) {
        var self = this;
        self.githubUser = params.githubUser;
    },
    template:
        '<div class="panel panel-primary stargezers-widget" data-bind="visible: githubUser().stargazers && githubUser().stargazers.length">\
            <div class="panel-heading">Stargazers</div>\
            <table class="table stargezers-table" data-bind="with: githubUser()">\
                <thead>\
                <tr>\
                    <th>Login</th>\
                </tr>\
                </thead>\
                <tbody class="repos-table-body" data-bind="foreach: stargazers">\
                <tr>\
                    <td data-bind="text: Login"></td>\
                </tr>\
                </tbody>\
            </table>\
        </div>'
});