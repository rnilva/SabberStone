from setuptools import setup, find_packages


setup(
    name="pysabberstone-pythonnet",
    version="0.0.1",
    packages=find_packages(),
    install_requires=[
        "pythonnet>=3.0.0",
    ],
    package_data={
        "pysabberstone": ["*.dll"],
    },
    include_package_data=True,
)
