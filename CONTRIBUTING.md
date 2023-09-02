# Contributing to RainbowStar

As a contributor, here are some guidelines that are expected to be followed:

## Commits

This specification is heavily based on the [AngularJS convention](https://docs.google.com/document/d/1QrDFcIiPjSLDn3EL15IJygNPiHORgU1_OOAqWjiDU5Y/edit#heading=h.uyo6cb12dt6w) and should be strictly applied when providing changes to the codebase. A simplified format leads to a consistent and comprehensible commit history, so the message's structure consists only of a `header` with the following format:

```
<type>(<scope>): <short summary>
```

The `<type>` and `<short summary>` fields are mandatory and the `<scope>` is optional. **Type** must be one of the options listed below:

* **build**: Changes that affect the build system or external dependencies
* **ci**: Changes to our CI configuration files and scripts
* **doc**: Documentation only changes
* **feat**: A new feature
* **fix**: A bug fix
* **perf**: A code change that improves performance
* **refac**: A code change that neither fixes a bug nor adds a feature
* **test**: Adding missing tests or correcting existing tests

## Pull Requests

The project's default branch is `main`, which contains a read-only protection so that users cannot push directly to it. Considering that, all commits must be made to a non-protected branch and submitted via a pull request before they can be merged to `main`.

After obtaining a working copy of the project via:

```bash
git clone https://github.com/gustavodiasag/RainbowStar.git
```

a new branch needs to be created with the name of the feature being implemented:

```bash
git checkout -b some-feature
# ...
git commit -a -m "feat(example): foo"
```

After the feature is complete, the pull request can be made through:

```bash
git push origin some-feature
```

When the pull request is "Ready for Review", select this option on the PR's page, which will notify maintainers to review the changes. See the [GitHub pull request tutorial](https://help.github.com/articles/using-pull-requests) for details.