//
//  MDPSubstitutionModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPSubstitutionModel.h"


#pragma mark  - SubstitutionReason
typedef NS_ENUM(NSInteger, MDPSubstitutionModelSubstitutionReason) {
    MDPSubstitutionModelSubstitutionReasonUnknow    = 0,
    MDPSubstitutionModelSubstitutionReasonInjury    = 1,
    MDPSubstitutionModelSubstitutionReasonTactical    = 2,
};


#pragma mark - Interface
@interface MDPSubstitutionModel : _MDPSubstitutionModel

+ (instancetype)insertWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
