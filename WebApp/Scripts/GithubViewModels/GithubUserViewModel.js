function GithubUserViewModel() {
    var self = this;
    self.githubUser = ko.observable({ show: false, repos: [], stargazers: [] });
}

ko.applyBindings(new GithubUserViewModel())