//
//  MDPTeamOfficialModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPTeamOfficialModel.h"

#pragma mark TeamOfficialType
typedef NS_ENUM(NSInteger, MDPTeamOfficialModelTeamOfficialType ) {
    MDPTeamOfficialModelTeamOfficialTypeManager              = 0,
    MDPTeamOfficialModelTeamOfficialTypeAssistantManager     = 1,
} ;


#pragma mark - Interface
@interface MDPTeamOfficialModel : _MDPTeamOfficialModel

+ (instancetype)insertIfNotExistsTeamOfficialWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
