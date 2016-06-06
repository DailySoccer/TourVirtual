//
//  _MDPGroupMemberModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPGroupMemberModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPGroupMemberModelAttributes {
	__unsafe_unretained NSString *alias;
	__unsafe_unretained NSString *idUser;
	__unsafe_unretained NSString *isAdmin;
	__unsafe_unretained NSString *lastUpdateAt;
} MDPGroupMemberModelAttributes;

extern const struct MDPGroupMemberModelRelationships {
	__unsafe_unretained NSString *pagedGroupMemberResults;
} MDPGroupMemberModelRelationships;

@class MDPPagedGroupMembersModel;

@interface _MDPGroupMemberModel : NSManagedObject

@property (nonatomic, strong) NSString* alias;

//- (BOOL)validateAlias:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idUser;

//- (BOOL)validateIdUser:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* isAdmin;

@property (atomic) BOOL isAdminValue;
- (BOOL)isAdminValue;
- (void)setIsAdminValue:(BOOL)value_;

//- (BOOL)validateIsAdmin:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPPagedGroupMembersModel *pagedGroupMemberResults;

//- (BOOL)validatePagedGroupMemberResults:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPGroupMemberModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAlias;
- (void)setPrimitiveAlias:(NSString*)value;

- (NSString*)primitiveIdUser;
- (void)setPrimitiveIdUser:(NSString*)value;

- (NSNumber*)primitiveIsAdmin;
- (void)setPrimitiveIsAdmin:(NSNumber*)value;

- (BOOL)primitiveIsAdminValue;
- (void)setPrimitiveIsAdminValue:(BOOL)value_;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (MDPPagedGroupMembersModel*)primitivePagedGroupMemberResults;
- (void)setPrimitivePagedGroupMemberResults:(MDPPagedGroupMembersModel*)value;

@end
