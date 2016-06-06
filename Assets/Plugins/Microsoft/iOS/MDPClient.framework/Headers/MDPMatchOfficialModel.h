//
//  MDPMatchOfficialModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPMatchOfficialModel.h"


#pragma mark  - MatchOfficialType
typedef NS_ENUM(NSInteger, MDPMatchOfficialModelMatchOfficialType) {
    MDPMatchOfficialModelMatchOfficialTypeUnknow         = 0,
    MDPMatchOfficialModelMatchOfficialTypeMain           = 1,
    MDPMatchOfficialModelMatchOfficialTypeLineman1       = 2,
    MDPMatchOfficialModelMatchOfficialTypeLineman2       = 3,
    MDPMatchOfficialModelMatchOfficialTypeFourthOfficial = 4,
};


#pragma mark - Interface
@interface MDPMatchOfficialModel : _MDPMatchOfficialModel

+ (instancetype)insertIfNotExistsMatchOfficialWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
