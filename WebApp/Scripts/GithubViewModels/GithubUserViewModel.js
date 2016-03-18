function GithubUserViewModel() {
    var self = this;

    self.githubUserLogin = ko.observable();
    self.githubUser = ko.observable({show:false});

    self.name = ko.observable();
    self.followerscount = ko.observable();
    self.publicrepos = ko.observable();

    self.login = ko.observable();
    self.reposData = ko.observable();
    self.stargazersData = ko.observable();

    self.showUserWidget = ko.observable(false);
    self.showReposWidget = ko.observable(false);
    self.showStargazersWidget = ko.observable(false);

    self.searchUser = function(formElement) {
        var searchInput = formElement.elements.userName;
        if (searchInput) {
            var searchInputValue = searchInput.value;
            self.login(searchInputValue);
            var url = '/api/search/users/' + searchInputValue;
            $.get(url, function(result) {
                self.name(result.Name);
                self.followerscount(result.Followers);
                self.publicrepos(result.Public_Repos);
                self.showUserWidget(true);
            }).fail(function() {
                self.showUserWidget(false);
            });
            self.showStargazersWidget(false);
            self.showReposWidget(false);
        }
    }

    self.getRepos = function() {
        var url = '/api/search/users/' + self.login() + '/repos';
        $.get(url, function (repos) {
            var result = { repos: repos};
            self.reposData(result);
            self.showReposWidget(true);
        }).fail(function () {
            self.showReposWidget(false);
        });
    }

    self.getStargazers = function (repo) {
        var url = '/api/search/users/' + self.login() + '/repos/' + repo.Name + '/stargazers';
        $.get(url, function (stargazers) {
            var result = { stargazers: stargazers };
            self.stargazersData(result);
            self.showStargazersWidget(true);
        }).fail(function () {
            self.showStargazersWidget(false);
        });
    }
}

ko.applyBindings(new GithubUserViewModel())