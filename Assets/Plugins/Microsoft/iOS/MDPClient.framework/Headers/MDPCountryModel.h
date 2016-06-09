//
//  MDPCountryModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPCountryModel.h"


#pragma mark - Interface
@interface MDPCountryModel : _MDPCountryModel

+ (NSArray *)countriesWithManagedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsCountryWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (NSMutableDictionary *)countriesWithLanguage:(NSString *)language managedObjectContext:(NSManagedObjectContext *)context;

+ (NSMutableDictionary *)countryWithLanguage:(NSString *)language countryCode:(NSString *)countryCode managedObjectContext:(NSManagedObjectContext *)context ;

@end
