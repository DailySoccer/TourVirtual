//
//  MDPPenaltyShotModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPPenaltyShotModel.h"


#pragma mark  - PenaltyShotOutcome
typedef NS_ENUM(NSInteger, MDPPenaltyShotModelPenaltyShotOutcome) {
    MDPPenaltyShotModelPenaltyShotOutcomeUnknow    = 0,
    MDPPenaltyShotModelPenaltyShotOutcomeMissed    = 1,
    MDPPenaltyShotModelPenaltyShotOutcomeScored    = 2,
};


#pragma mark - Interface
@interface MDPPenaltyShotModel : _MDPPenaltyShotModel

+ (instancetype)insertWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
