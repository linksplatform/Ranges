#!/bin/bash
set -e # Exit with nonzero exit code if anything fails

bash fmt.sh > fmt.tex
make
mkdir _site
cp fmt.pdf _site/Platform.$TRAVIS_REPO_NAME.pdf
