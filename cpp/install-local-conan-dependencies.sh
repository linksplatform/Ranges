git clone https://github.com/linksplatform/conan-center-index
cd conan-center-index && git checkout only-development && cd recipes
conan create platform.converters/all platform.converters/0.1.0@ -pr=linksplatform
conan create platform.exceptions/all platform.exceptions/0.2.0@ -pr=linksplatform
conan create platform.hashing/all platform.hashing/0.2.0@ -pr=linksplatform
