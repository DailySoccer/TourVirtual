//
//  _MDPRequestJoinGroupModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPRequestJoinGroupModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPRequestJoinGroupModelAttributes {
	__unsafe_unretained NSString *alias;
	__unsafe_unretained NSString *groupName;
	__unsafe_unretained NSString *idGroup;
	__unsafe_unretained NSString *idJoinRequest;
	__unsafe_unretained NSString *idUser;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *requestDate;
} MDPRequestJoinGroupModelAttributes;

extern const struct MDPRequestJoinGroupModelRelationships {
	__unsafe_unretained NSString *pagedRequestJoinGroupResults;
} MDPRequestJoinGroupModelRelationships;

@class MDPPagedRequestJoinGroupModel;

@interface _MDPRequestJoinGroupModel : NSManagedObject

@property (nonatomic, strong) NSString* alias;

//- (BOOL)validateAlias:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* groupName;

//- (BOOL)validateGroupName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idGroup;

//- (BOOL)validateIdGroup:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idJoinRequest;

//- (BOOL)validateIdJoinRequest:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idUser;

//- (BOOL)validateIdUser:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* requestDate;

//- (BOOL)validateRequestDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPPagedRequestJoinGroupModel *pagedRequestJoinGroupResults;

//- (BOOL)validatePagedRequestJoinGroupResults:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPRequestJoinGroupModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAlias;
- (void)setPrimitiveAlias:(NSString*)value;

- (NSString*)primitiveGroupName;
- (void)setPrimitiveGroupName:(NSString*)value;

- (NSString*)primitiveIdGroup;
- (void)setPrimitiveIdGroup:(NSString*)value;

- (NSString*)primitiveIdJoinRequest;
- (void)setPrimitiveIdJoinRequest:(NSString*)value;

- (NSString*)primitiveIdUser;
- (void)setPrimitiveIdUser:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSDate*)primitiveRequestDate;
- (void)setPrimitiveRequestDate:(NSDate*)value;

- (MDPPagedRequestJoinGroupModel*)primitivePagedRequestJoinGroupResults;
- (void)setPrimitivePagedRequestJoinGroupResults:(MDPPagedRequestJoinGroupModel*)value;

@end
